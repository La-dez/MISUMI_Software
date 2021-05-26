00/*
 * Firmata is a generic protocol for communicating with microcontrollers
 * from software on a host computer. It is intended to work with
 * any host computer software package.
 *
 * To download a host software package, please clink on the following link
 * to open the download page in your default browser.
 *
 * http://firmata.org/wiki/Download
 */

/* Supports as many analog inputs and analog PWM outputs as possible.
 *
 * This example code is in the public domain.
 */
#include <Firmata.h>

byte analogPin = 0;
byte PWM_pin = 13;
unsigned long currentMillis;     // store the current value from millis()
unsigned long previousMillis;    // for comparison with currentMillis
unsigned int Delay_ms = 100;

byte previousPIN[TOTAL_PORTS];  // PIN means PORT for input
byte previousPORT[TOTAL_PORTS]; 

void outputPort(byte portNumber, byte portValue)
{
    // only send the data when it changes, otherwise you get too many messages!
    if (previousPIN[portNumber] != portValue) {
        Firmata.sendDigitalPort(portNumber, portValue); 
        previousPIN[portNumber] = portValue;
    }
}

void setPinModeCallback(byte pin, int mode) 
{
    if (IS_PIN_DIGITAL(pin)) {
        pinMode(PIN_TO_DIGITAL(pin), mode);
    }
}

void digitalWriteCallback(byte port, int value)
{
    byte i;
    byte currentPinValue, previousPinValue;

    if (port < TOTAL_PORTS && value != previousPORT[port]) {
        for(i=0; i<8; i++) {
            currentPinValue = (byte) value & (1 << i);
            previousPinValue = previousPORT[port] & (1 << i);
            if(currentPinValue != previousPinValue) {
                digitalWrite(i + (port*8), currentPinValue);
            }
        }
        previousPORT[port] = value;
    }
}
void analogWriteCallback(byte pin, int value)
{    
        analogWrite(PIN_TO_PWM(PWM_pin), value);
}



void setup()
{
    Firmata.setFirmwareVersion(0, 1);
    Firmata.attach(ANALOG_MESSAGE, analogWriteCallback);   
   // Firmata.attach(SET_PIN_MODE, setPinModeCallback);
    Firmata.begin(57600);
    pinMode(PIN_TO_DIGITAL(PWM_pin), OUTPUT);
  //  pinMode(PIN_TO_DIGITAL(1), OUTPUT);
  //  pinMode(PIN_TO_DIGITAL(2), OUTPUT);
  //  pinMode(PIN_TO_DIGITAL(3), OUTPUT);
  //  pinMode(PIN_TO_DIGITAL(4), OUTPUT);
  //  pinMode(PIN_TO_DIGITAL(5), OUTPUT);
}

void loop()
{
    while(Firmata.available()) {
        Firmata.processInput();
    }
    // do one analogRead per loop, so if PC is sending a lot of
    // analog write messages, we will only delay 1 analogRead
    //Firmata.sendAnalog(0, analogRead(0)); 
    
    byte i;
   /* for (i=0; i<13; i++) 
    {
        outputPort(i, readPort(i, 0xff));
    }*/
    /* for (i=0; i<TOTAL_PORTS; i++) 
    {
        outputPort(i, readPort(i, 0xff));
    }*/
    
    //24/05/2021 test_3 for read stability. Result: read - ? need more tests. Writing - nice
    currentMillis = millis();
    if(currentMillis - previousMillis > Delay_ms) {  
          previousMillis += Delay_ms;                   // run this every 20mss
          Firmata.sendAnalog(0, analogRead(0));    
    }
  
    //24/05/2021 test_1 for read stability. Result: read - ? Writing - laggy
  //  Firmata.sendAnalog(analogPin, analogRead(analogPin)); 
  //  analogPin = analogPin + 1;
  //  if (analogPin >= TOTAL_ANALOG_PINS) analogPin = 0;
    
       //24/05/2021 test_2 for read stability. Result: read - some shit. Writing - laggy
   // Firmata.sendAnalog(0, analogRead(0)); 
}

