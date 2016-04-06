// Tested on Arduino 1.0.3


#include <SPI.h>         // needed for Arduino versions later than 0018
#include <Ethernet.h>
#include <EthernetUdp.h>          // UDP library from: bjoern@cs.stanford.edu 12/30/2008


// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
byte mac[] = {  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xEE };
byte ip[] = {  192,168,1,177 };

const unsigned int localPort = 8890;      // local port to listen on

// buffers for receiving and sending data
char packetBuffer[UDP_TX_PACKET_MAX_SIZE]; //buffer to hold incoming packet,
char  replyBuffer[] = "ok";       // a string to send back

const int forward_pin = 8;    // forward pin
const int backward_pin = 9;    // forward pin
const int left_pin = 3;    // forward pin
const int right_pin = 2;    // forward pin

//
int voltage_pin = 0;
int vin = 0;
const int R1 = 20400;    // !! resistance of R1 !!
const int R2 = 9230;     // !! resistance of R2 !!
const float resistorFactor = 1000*5.0*(R1+R2)/(R2 * 1024.0); 
  
// An EthernetUDP instance to let us send and receive packets over UDP
EthernetUDP Udp;

void setup() 
{
  //analog pins
  pinMode(voltage_pin, INPUT);
  
  // start the Ethernet and UDP:
  Ethernet.begin(mac,ip);
  Udp.begin(localPort);
  
  // do we need this
  pinMode(forward_pin, OUTPUT);
  pinMode(backward_pin, OUTPUT);
  pinMode(left_pin, OUTPUT);
  pinMode(right_pin, OUTPUT);
  
  //

  Serial.begin(9600);
}

void loop() 
{
  delay(10);  
 
  // if there's data available, read a packet
  int readPacketSize = Udp.parsePacket(); // note that this includes the UDP header
  
  if(readPacketSize<=0)
    return;
    
  readPacketSize = readPacketSize - 8;      // subtract the 8 byte header
  Serial.print("Received packet of size ");
  Serial.println(readPacketSize);

  memset(packetBuffer, 0, sizeof(packetBuffer));
  // read the packet into packetBufffer and get the senders IP addr and port number
  Udp.read(packetBuffer, UDP_TX_PACKET_MAX_SIZE);
  Serial.println("Contents:");
  Serial.println(packetBuffer);
  
  bool update_cmd = false;
  
  if( strcmp(packetBuffer, "forward1") == 0)
  {
    digitalWrite(forward_pin, HIGH);
    Serial.println("forward command received");
  }else
  if( strcmp(packetBuffer, "backward1") == 0)
  {
    digitalWrite(backward_pin, HIGH);
    Serial.println("backward command received");
  }else
  if( strcmp(packetBuffer, "left1") == 0)
  {
    digitalWrite(left_pin, HIGH);
    Serial.println("left command received");
  }else
  if( strcmp(packetBuffer, "right1") == 0)
  {
    digitalWrite(right_pin, HIGH);
    Serial.println("right command received");
  }else ///////////////////////////////////////////
  if( strcmp(packetBuffer, "forward0") == 0)
  {
    digitalWrite(forward_pin, LOW);
    Serial.println("forward command received");
  }else
  if( strcmp(packetBuffer, "backward0") == 0)
  {
    digitalWrite(backward_pin, LOW);
    Serial.println("backward command received");
  }else
  if( strcmp(packetBuffer, "left0") == 0)
  {
    digitalWrite(left_pin, LOW);
    Serial.println("left command received");
  }else
  if( strcmp(packetBuffer, "right0") == 0)
  {
    digitalWrite(right_pin, LOW);
    Serial.println("right command received");
  }else
  if( strcmp(packetBuffer, "update") == 0)
  {
    update_cmd = true;
    
    vin = analogRead(voltage_pin) * resistorFactor;
    
    char str_voltage[16];
    sprintf(str_voltage, "vlt %d", vin);
    
    Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
    Udp.write(str_voltage);
    Udp.endPacket(); 
    
    Serial.println("update command received");
  }

  if(update_cmd == false)
  {
    Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
    Udp.write(replyBuffer);
    int sentPacketSize = Udp.endPacket(); 
    
    // if we failed to sent ok, we turn off all pins
    if(sentPacketSize == 0)
    {
      digitalWrite(forward_pin, LOW);
      digitalWrite(backward_pin, LOW);
      digitalWrite(left_pin, LOW);
      digitalWrite(right_pin, LOW);
    }
  }
  
}


/*
  Processing sketch to run with this example
 =====================================================
 
 // Processing UDP example to send and receive string data from Arduino 
 // press any key to send the "Hello Arduino" message
 
 
 import hypermedia.net.*;
 
 UDP udp;  // define the UDP object
 
 
 void setup() {
 udp = new UDP( this, 6000 );  // create a new datagram connection on port 6000
 //udp.log( true ); 		// <-- printout the connection activity
 udp.listen( true );           // and wait for incoming message  
 }
 
 void draw()
 {
 }
 
 void keyPressed() {
 String ip       = "192.168.137.177";	// the remote IP address
 int port        = 8888;		// the destination port
 
 udp.send("Hello World", ip, port );   // the message to send
 
 }
 
 void receive( byte[] data ) { 			// <-- default handler
 //void receive( byte[] data, String ip, int port ) {	// <-- extended handler
 
 for(int i=0; i < data.length; i++) 
 print(char(data[i]));  
 println();   
 }
 */


