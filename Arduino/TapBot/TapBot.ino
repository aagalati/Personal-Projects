
//this code uses the servo library to move a servo connected to the arduino in the real world
//the servo has a stylus attached to it, which taps the phone based on the motion of the servo


#include <Servo.h>

Servo myservo;  
bool reset;
int countreset;

int pos = 0;  

void setup() {
  //Serial.begin(9600);
  //Serial.print("---Adventure Capitalist Press Bot ON----");
  myservo.attach(9);
  reset = false;
  countreset = 0;
  myservo.write(180);
}

void loop() {

while(true) {

while(!reset) {

    for (pos = 135; pos <= 165; pos += 3) { 
      // in steps of 1 degree
      myservo.write(pos);              
      delay(10);                       
    }
    for (pos = 165; pos >= 135; pos -= 3) { 
      myservo.write(pos);            
      delay(10);                       
    }     

    countreset++;
    //Serial.print(countreset);
    if (countreset >= 50) reset = true;

}

delay(100);
myservo.write(180);
countreset = 0;
reset = false;
//Serial.print("Bot is paused for reset..");
delay(1000);

}
  
}
  

