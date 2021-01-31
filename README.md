# MiniTalk项目简介

+ 项目创建时间:2019-11-8 
+ 采用框架:.NetFrameWork 4.5

## 功能描述

### 基本聊天:

1. 输入@能够选择@对象,@全体次数用完后其他用户不再接收到全体提醒 
2. 点击表情即可插入表情到气泡，发送后即可看见,由于分辨率原因,1920*1080才能完整显示表情 
3. Ctrl+Alt+S 能够屏幕截图,只能保存到剪切板，然后即可在输入框粘贴发送(不能大于3M)  
---
### 文件发送
1. 文件发送只能发送单个文件,若有多个请压缩发送 

2. 输入框支持粘贴文件,粘贴后直接发送 

3. 出于性能和学校机房配置考虑,公共回话只能发送小于10MB的文件,私人会话无限制 

   ---

### 远程协助

1. 在和和单个用户的聊天面板中会显示远程协助按钮

2. 支持邀请和发起,等待对方同意后即可建立连接,采用RDP 的Wndows Com组件,效果不错

   

### 其他功能:

1. 有多个同时在线用户时支持点击放大镜根据ip/备注/昵称模糊查找 
2. :窗口支持点击三角箭头折叠/展开,折叠后将窗体拖到屏幕上方自动隐藏 
3. :右击用户在线栏展开用户管理功能菜单,支持IP备注(备注后只要该IP上线依然显示其备注),加入黑名单和用户置顶 

### 未能解决的问题

1. 聊天面板偶尔上面会多出很大空白,设置MaxSize都无效
2. 远程协助偶尔连接失败
3. 文件拖放发送有时编译后能使用,有时不能
4. 生产模式时,远程协助模块有时编译后能使用,有时不能(有时在源文件中逛一下再编译就好了)
5. c# 绘制性能无解

## 程序截图

### 创建角色页面

![Image 20210131202313158](https://gitee.com/haodong108/mini-talk/blob/master/Screenshot/image-20210131202313158.png)

### 头像选择

![Image 20210131202431816](https://gitee.com/haodong108/mini-talk/blob/master/Screenshot/image-20210131202431816.png)

### 主体界面

![Image 20210131202612162](https://gitee.com/haodong108/mini-talk/blob/master/Screenshot/image-20210131202612162.png)

![Image 20210131202756421](https://gitee.com/haodong108/mini-talk/blob/master/Screenshot/image-20210131202756421.png)

### 程序设置

![Image 20210131202827129](https://gitee.com/haodong108/mini-talk/blob/master/Screenshot/image-20210131202827129.png)

### 远程协助

[单机无法调试]

