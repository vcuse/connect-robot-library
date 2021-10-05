# connect-robot-library

This repository stores the connectRobot library, which will be implemented within unity to create a client-server connection between Unity 3D and Robot Studio utilizing the Rest API Robot Web Services. 

**In order to attach and execute the library in a C# Visual Studio project:**

1. Install Newtonsoft.Json and RestSharp NuGet packages into C# script
2. Navigate to your C# project. In the "Project" tab above, click on "Add Project Reference". 
3. In the Reference Manager window, click on the tab "Browse" on the left hand side. Then, click on the "Browse" button at the bottom of the screen. Navigate to the connectRobot.dll file on your computer, click it, and then click the "Add" button in the file explorer.
4.  Ensure that the connectRobot.dll file has a check mark next to it in the Reference Manager window. Click "Ok" at the bottom of the Reference Manager window. 
5.  Check that the  connectLibrary.dll file is listed under the Dependencies->Assemblies section of your Solution Explorere window [located on the left-hand side of your screen]. 
6.  write "using connectRobot" at the top of your C# script

**In order to attach and execute the library in a Unity project:**
1. Install NuGetForUnity package into your Unity project using the following link: https://github.com/GlitchEnzo/NuGetForUnity/releases
2. Using the new NuGet tab above, install the RestSharp package into your project. 
3. Copy and paste the connectRobot.dll file into your asset folder in Unity.
4. Within the C# Unity Script that you would like to utilize the connectRobot library, type "using connectRobot" at the top of the script.


*Implement the following code into the void Start() function of Unity:*

     string ipaddress = "127.0.0.1";
  
     string port = "80";
  
     string mechanism = "ROB_1";
     
     sendCommand myobj = new sendCommand(ipaddress, port, mechanism);
  
The preceding code initializes the robot controller's ip adress and port information. It also initializes the connection between the robot controller and the Unity projejct. Ensure that before you run this code, that the ip adress and port numbers are correct. Also, make sure that your Robot Controller is on and that the FlexPendant is placed in manual mode with the "Motors ON". Make sure to grant RMMP access within 5 seconds of starting code. 
