# RaspDuino_I2C_Communication
This simple solution has 2 projects, the part of arduino and the raspberry code (UWP)

Hi Everyone!
In today's world, every electronics hobbyist works with Arduino and Raspberry Pi to do his/her projects. With the introduction of Windows 10 IOT Core, Microsoft is also into the embedded world. Today Internet Of Things is a buzzword, but for basic things we need an Arduino to communicate with a Raspberry Pi. In this project I will explain how to communicate the Arduino with the Pi using an I2C bus and Windows 10 IOT Core.


With the Raspberry, I have used windows 10 IOT core and have developed a Windows UWP app which reads data from Arduino and displays it. You can use Windows IOT Remote Client to remotely connect to the Raspberry Pi. First extract the code and open .sln file and dump the code in Raspberry Pi. 

Analog pin 4 and 5 are used as SDA and SCL lines which are required to have I2C Communication and these pins need not be initiated. By default they will be acting as SDA and SCL.
Arduino sends data read from LDR to Pi using the function: 
Wire.write(response)


