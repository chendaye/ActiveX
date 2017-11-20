# ActiveX
一、创建 .NET Framework 类库项目

二、实现 IObjectSafety 接口（浏览器安全需要）

三、创建 Guid （第5种类型）

四、类库属性-> 选择目标框架（建议.NET Framework 4 win10默认版本）->程序集信息->使程序集COM可见 -> 生成 ->  为COM互相操作注册 （注意是Debug 还是 Release）

五、Debug  创建控制台应用测试

六、创建安装项目 Setup Project -> 添加项目输出（类库项目） -> 主输出属性->Register /vsdrpCOM ->生成

七、创建 Cab Project -> 添加项目输出(Setup 安装项目) -> 生成

八、给 Cab 数字签名（具体参见tool）

九、安装.exe文件时，选择 “所有人” ,一些功能需要用到管理员权限
