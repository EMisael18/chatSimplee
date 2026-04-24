using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ChatSimple
{
    public partial class frmServidor : Form
    {
        private List<StreamWriter> clientesConectados = new List<StreamWriter>();
        private readonly object lockClientes = new object();

        Conexion db = new Conexion();

        public frmServidor()
        {
            InitializeComponent();
        }

        private async void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.Puerto = int.Parse(txtPuerto.Text);

                Conexion.IpServidor = getIP();


                DataSet ds = db.ejecutar("SELECT usuario, mensaje, timestamp FROM historico");

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];

                        string usuario = row["usuario"].ToString();
                        string mensaje = row["mensaje"].ToString();
                        string fecha = row["timestamp"].ToString();

                        rtbHistorial.AppendText("[" + fecha + "] " + usuario + ": " + mensaje + "\r\n");
                    }
                }

                TcpListener listener = new TcpListener(IPAddress.Any, Conexion.Puerto);
                listener.Start();

                rtbHistorial.AppendText("Servidor iniciado en: " + Conexion.IpServidor + ":" + Conexion.Puerto + "\r\n");

                while (true)
                {
                    TcpClient nuevoCliente = await listener.AcceptTcpClientAsync();
                    _ = ManejarCliente(nuevoCliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task ManejarCliente(TcpClient cliente)
        {
            NetworkStream stream = cliente.GetStream();
            StreamReader clientReader = new StreamReader(stream);
            StreamWriter clientWriter = new StreamWriter(stream) { AutoFlush = true };
            string nombreCliente = "";
            try
            {
                nombreCliente = await clientReader.ReadLineAsync();

            DataSet ds = db.ejecutar("SELECT usuario, mensaje, timestamp FROM historico");

            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];

                    string usuario = row["usuario"].ToString();
                    string mensaje = row["mensaje"].ToString();
                    string fecha = row["timestamp"].ToString();

                    string linea = "[" + fecha + "] " + usuario + ": " + mensaje;

                    await clientWriter.WriteLineAsync(linea);
                }
            }

            lock (lockClientes) { clientesConectados.Add(clientWriter); }

            rtbHistorial.Invoke((MethodInvoker)delegate {
                rtbHistorial.AppendText(nombreCliente + " se unió al chat\r\n");
            });

            DifundirMensaje(nombreCliente + " se unió al chat");

           
                while (cliente.Connected)
                {
                    string mensajeRecibido = mensajeRecibido = await clientReader.ReadLineAsync();

                    if (mensajeRecibido == null)
                    {
                        break;
                    }

                    string fechaHora = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

                    string MensajeFinal = "[" + fechaHora + "] " + nombreCliente + ": " + mensajeRecibido;

                    rtbHistorial.Invoke((MethodInvoker)delegate {
                        rtbHistorial.AppendText(MensajeFinal + "\r\n");
                    });

                    DifundirMensaje(MensajeFinal);

                    string fechaYhora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    db.ejecutarcomando("INSERT INTO historico (usuario, mensaje, timestamp) VALUES ('"
                        + nombreCliente + "','" + mensajeRecibido + "','" + fechaYhora + "')");
                }
            }
            catch { }
            finally
            {
                lock (lockClientes) { clientesConectados.Remove(clientWriter); }

                rtbHistorial.Invoke((MethodInvoker)delegate {
                    rtbHistorial.AppendText(nombreCliente + " salió del chat\r\n");
                });

                DifundirMensaje(nombreCliente + " salió del chat");

                cliente.Close();
            }
        }

        private async void DifundirMensaje(string mensaje)
        {
            List<StreamWriter> copiaClientes;

            lock (lockClientes) { copiaClientes = new List<StreamWriter>(clientesConectados); }

            foreach (var clientWriter in copiaClientes)
            {
                try
                {
                    await clientWriter.WriteLineAsync(mensaje);
                }
                catch { }
            }
        }

        private string getIP()
        {
            string hostName = Dns.GetHostName();
            string myIP = "";
            IPHostEntry host = Dns.GetHostEntry(hostName);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = ip.ToString();
                    break;
                }
            }
            return myIP;
        }
    }
}