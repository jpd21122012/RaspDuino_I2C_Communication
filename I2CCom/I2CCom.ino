#include <Wire.h>  // Library which contains functions to have I2C Communication
#define SLAVE_ADDRESS 0x53 // Define the I2C address to Communicate to Leonardo,0x40 to Uno

byte response[2]; // this data is sent to PI
volatile short value; // Global Declaration

void setup() {
	Serial.begin(9600);
	Wire.begin(SLAVE_ADDRESS); // this will begin I2C Connection with 0x40 address
	Wire.onRequest(sendData); // sendData is funtion called when Pi requests data
}

void loop() {
	delay(1000);
}

void sendData() {
	value = Serial.read();
	response[0] = (byte)value;
	Wire.write(response, 2); // return data to PI
}