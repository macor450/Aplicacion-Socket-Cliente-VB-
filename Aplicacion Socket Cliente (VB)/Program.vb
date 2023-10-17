Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Namespace AplicaciondeSocketVBNet
    Class Program
        Shared Sub Main(args As String())
            Dim host As IPHostEntry = Dns.GetHostEntry("localhost")
            Dim ipAddress As IPAddress = host.AddressList(0)
            Dim remoteEp As New IPEndPoint(ipAddress, 11200)
            Try
                Dim sender As New Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                sender.Connect(remoteEp)

                Console.WriteLine("Conectando con el servidor")
                Console.WriteLine("Ingrese un texto que quiere enviar")
                Dim texto As String = Console.ReadLine()

                Dim msg As Byte() = Encoding.ASCII.GetBytes(texto & "<EOF>")
                Dim byteSent As Integer = sender.Send(msg)

                sender.Shutdown(SocketShutdown.Both)
                sender.Close()
            Catch e As Exception
                Console.WriteLine(e.ToString())
            End Try
        End Sub
    End Class
End Namespace
