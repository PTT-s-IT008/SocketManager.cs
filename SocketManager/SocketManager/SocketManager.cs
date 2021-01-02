using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketManager
{
    #region code mẫu copy không xài
    public class SocketManager
    {
        #region client 
        Socket client;
        
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP),PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(iep);
                return true;
            } 
            catch
            {
                return false;
            }
            
            
        }
        #endregion

        #region server
        Socket server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(iep);
            server.Listen(10);

            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();
            
        }
        #endregion

        #region both
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public bool isServer = true;
        public const int BUFFER = 1024*5000;

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }

        public bool Send(object data, Socket client)
        {
            byte[] sendData = SerializeData(data);
            return SendData(client, sendData);
        }
        public object Receive(Socket client)
        {
            byte[] receiveData = new byte[BUFFER];
            bool isOk = ReceiveData(client, receiveData);
            return DeserializeData(receiveData);
        }
        public  object Receive()
        {
            byte[] receiveData = new byte[BUFFER];
            bool isOk = ReceiveData(client, receiveData);
            return DeserializeData(receiveData);
        }

        private  bool SendData(Socket target,byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }

        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

        /// <summary>
        /// Nén đối tượng thành mảng byte[]
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        /// <summary>
        /// Giải nén mảng byte[] thành đối tượng object
        /// </summary>
        /// <param name="theByteArray"></param>
        /// <returns></returns>
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        /// <summary>
        /// Lấy ra IP V4 của card mạng đang dùng
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion

    }
    #endregion


    #region managing data and sockets
    static class DataSerialization
    {
        /// <summary>
        /// Nén đối tượng thành mảng byte[]
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        static public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        /// <summary>
        /// Giải nén mảng byte[] thành đối tượng object
        /// </summary>
        /// <param name="theByteArray"></param>
        /// <returns></returns>
        static public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        /// <summary>
        /// Lấy ra IP V4 của card mạng đang dùng
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        static public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
    }
    public class User
    {
        public string username;
        public bool gotUsername = false;
        public Socket socket;

        public Debugger.delDebugger toScreen;
        public delegate string  getUsername();
        public getUsername delUserList;
        

        public void Initialize()
        {
            Thread receivingData = new Thread(() =>
            {
                while (true)
                {
                    
                    try
                    {
                        string DataReceived = (string)this.Receive(socket);
                        toScreen(DataReceived);
                        // data manipulation
                        string command = DataReceived.Split('\n')[0];
                        string content = DataReceived.Split('\n')[1];
                        string destination = DataReceived.Split('\n')[2];

                        switch(command)
                        {
                            case "get_username":
                                {
                                    username = content;
                                    gotUsername = true;
                                    toScreen(username + " has got username \n");
                                    break;

                                }
                            case "get_userlist":
                                {
                                    string newdata = "userlist\n";
                                    newdata += delUserList;
                                    Send(newdata);
                                    break;
                                }
                        }
                        
                    }
                    catch { }
                }
            });

            receivingData.IsBackground = true;
            receivingData.Start();
        }

        public bool Send(object data)
        {
            byte[] sendData = DataSerialization.SerializeData(data);
            return SendData(socket, sendData);
        }

       
        public object Receive(Socket client)
        {
            byte[] receiveData = new byte[5000*1024];
            bool isOk = ReceiveData(client, receiveData);
            return DataSerialization.DeserializeData(receiveData);
        }
        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }

       

    }

    public static class Debugger
    {
        public delegate void delDebugger(string s);
        
    }
    #endregion

    #region client and server
    public class Server
    {
        #region properties
        public Socket socket;



        public List<User> userList = new List<User>();

        
        public Debugger.delDebugger toScreen;
        #endregion

        #region method
        // Tạo ra một server
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9999);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(iep);
            socket.Listen(10);

            Thread acceptClient = new Thread(() =>
            {
                while(true)
                {
                    if (socket.Accept() != null)
                    {
                        User newuser = new User();
                        newuser.socket = this.socket.Accept();
                        newuser.toScreen = this.toScreen;
                        newuser.Initialize();
                        userList.Add(newuser);
                    }
                }
               

                

            });
            acceptClient.IsBackground = true;
            acceptClient.Start();

        }
        // Hàm kiểm tra connected
        public bool IsConnected(Socket s)
        {
            try
            {
                return !(s.Poll(1, SelectMode.SelectRead) && s.Available == 0);
            }
            catch (SocketException) { return false; }
        }
        
        // Thread kiểm tra nếu user disconnect
        public void CheckDisconnect()
        {
            Thread checkConnectionOfUser = new Thread(() =>{
                while(true)
                {
                    if(userList.Count != 0)
                    {
                        foreach(User user in userList)
                        {
                            if(!IsConnected(user.socket))
                            {
                                toScreen(user.username + " has disconnected. \n");
                                user.socket.Close();
                                userList.Remove(user);

                            }
                        }
                    }
                }

            });
        }

        // gửi data cụ thể cho một user theo username ( tất nhiên là phải cập nhật username rồi )
        public void sendDataThroughUsername(string username, string data)
        {
            if(userList.Count != 0)
            {
                foreach(User user in userList)
                {
                    if (user.gotUsername == true)
                    {
                        if (user.username == username)
                        {
                            user.Send(data);
                        }
                    }
                }
            }
        }

        // hiện danh sách username
        public void listRender()
        {
            if(userList.Count != 0)
            {
                foreach(User user in userList)
                {
                    toScreen(user.username + '\n');
                }
            }
        }
        
        public string showUserList()
        {
            string userlist="";
            foreach(User user in userList)
            {
                userlist += user.username + '/';
            }
            return userlist;
        }
        #endregion
    }
    public class Client
    {
        public Socket socket;
        public string username;
        public string IP;
        public Debugger.delDebugger toScreen;
        
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), 9999);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(iep);
                return true;
            }
            catch
            {
                MessageBox.Show(" Connection Error");
                return false;
            }
        }

        public void Initialize()
        {
            if (ConnectServer())
                if (sendUsername())
                {
                    {
                        Thread receiveData = new Thread(() =>
                        {
                            while (true)
                            {
                                try
                                {
                                    string data = (string)Receive(socket);
                                    // data manipulation

                                    toScreen(data);
                                }
                                catch
                                { }
                            }
                            
                        });

                        receiveData.IsBackground = true;
                        receiveData.Start();
                    }
                }
        }

        #region send and receive data
        public bool Send(object data)
        {
            byte[] sendData = DataSerialization.SerializeData(data);
            return SendData(socket, sendData);
        }


        public object Receive(Socket client)
        {
            byte[] receiveData = new byte[5000 * 1024];
            bool isOk = ReceiveData(client, receiveData);
            return DataSerialization.DeserializeData(receiveData);
        }
        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        #endregion

        public bool sendUsername()
        {
            string data = "get_username\n";
            data += username + '\n';
            try
            {
                Send(data);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool sendCommand(string command, string content, string destination)
        {
            string data = command + '\n' + content + '\n' + destination + '\n';
            try
            {
                Send(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
    #endregion
}
