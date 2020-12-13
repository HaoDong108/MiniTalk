        public Socket port5receSocket;

        Keydata key;
        Form1 form1;
        public ReceiveMessage(Keydata key,Form1 form1)
        {
            this.key = key;
            this.form1 = form1;
            port1receSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            port2receSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            port3receSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            port4receSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            port5receSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);           

           
                port1receSocket.Bind(new IPEndPoint(IPAddress.Parse(key.Localip), key.port1));
                port2receSocket.Bind(new IPEndPoint(IPAddress.Any, key.port2));
                port3receSocket.Bind(new IPEndPoint(IPAddress.Any, key.port3));
                port4receSocket.Bind(new IPEndPoint(IPAddress.Any, key.port4));
                //port5receSocket.Bind(new IPEndPoint(IPAddress.Any, key.port5));
     

            thread1 = new Thread(new ThreadStart(ReadMessage_port1));
            thread2 = new Thread(new ThreadStart(Rea