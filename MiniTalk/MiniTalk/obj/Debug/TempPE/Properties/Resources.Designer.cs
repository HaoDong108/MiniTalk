          {
                try
                {
                    //接收消息
                    port3receSocket.ReceiveFrom(bytetemp, ref userEndpoint);
                    message = Encoding.UTF8.GetString(bytetemp);
                    //截取数据有效部分
                    int re = message.LastIndexOf(key.EndStr);
                    if (re >= 0){message = message.Substring(0, re);}
                    else
                    {
                        continue;
                    }
                    userInformation = message.Split(':');
                    UserData userData = new UserData();
                    userData.Name = userInformation[0];
                    userData.IP = userInformation[1];
                    userData.UserPoint = new IPEndPoint(IPAddress.Parse(userInformation[1]), key.port3);

                    //检查在线用户表中是否已经存在该用户
                    try
                    {
                        foreach (var item in key.userStruchOnline)
                        {
                            //如果重复则抛出异常
                            if (item.IP.Equals(userData.IP))
                            {
                                throw new Exception();
                            }
                        }
                    }
                    catch (Exception)//捕捉异常，在主循环中跳出当次循环
                    {  
                        continue;
                    }

                    key.userStruchOnline.Add(userData);//将用户添加到在线用户集合中
                    form1.ListBoxItemsAdd(userInformation[0],userInformation[1]);//将该用户添加到listbox中,并且向目标主机回送一条上线消息
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
        /// <summary>
        /// 接收用户下线端口的消息，便于移除该用户
        /// </summary>
        private void ReadMessage_port4()
        {
            byte[] bytes = new byte[20];
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                this.port4receSocket.ReceiveFrom(bytes, ref endPoint);
                String message = Encoding.UTF8.GetString(bytes) + "\n";
                //提取出结束符的索引位置
                int re = message.LastIndexOf(key.EndStr);
                form1.RemoveUser(message.Substring(0, re));
            }
        }
        /// <summary>
        /// 接收功能控制端口消息
        /// </summary>
        private void ReadMessage_port5()
        {

        }

        /// <summary>
        /// 调用form1的添加方法将接受的