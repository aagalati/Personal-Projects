
//this code utlizes an 8 bit shift register to output different light sequences along 4 leds
//the light sequences are changed by physically clicking 4 different buttons on the board to cycle
//through 4 different modes.

  int latchPin = 4;
  int clockPin = 3;
  int dataPin = 2;

  int button1pin = 5;
  int button2pin = 6;
  int button3pin = 7;
  int button4pin = 8;
  int type = 0;
  
  int count = 0;
  int increment = 0;
  int data = 0;

  int phase = 0;

void setup() {

  Serial.begin(9600);
  Serial.println("Starting Sequencer");
  
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);

  pinMode(button1pin, INPUT);
  pinMode(button2pin, INPUT);
  pinMode(button3pin, INPUT);
  pinMode(button4pin, INPUT);

  digitalWrite(latchPin, LOW);
  shiftOut(dataPin, clockPin, MSBFIRST, 255);
  digitalWrite(latchPin, HIGH);

  delay(2000); 

  digitalWrite(latchPin, LOW);
  shiftOut(dataPin, clockPin, MSBFIRST, 0);
  digitalWrite(latchPin, HIGH);

}

void loop() {


    if (digitalRead(button1pin) == LOW) {
      type = 1;
      count = 0;
      data = 0;
    }

    if(digitalRead(button2pin) == LOW) {
      type = 2;
      count = 0;
      data = 0;
      phase = 0;
    }

    if(digitalRead(button3pin) == LOW) {
     type = 3;
    }

    if (digitalRead(button4pin) == LOW) {
      type = 4;
      count = 0;
    }

    digitalWrite(latchPin, LOW);
    shiftOut(dataPin, clockPin, MSBFIRST, data);
    digitalWrite(latchPin, HIGH);  

    if (type == 1) {
    
        if (count < 2) increment = pow(2, count);
        else increment = pow(2, count) + 1;
        
        data += increment;
    
        
    
        delay(75);
        
        count++;  
    
       if (data == 511) {
          data = 0;
         count = 0;
       }
  
    }

    if(type == 2) {

    
     if (phase == 0) { 
       if (count < 2) increment = pow(2, count);
                else increment = pow(2, count) + 1;
                data = increment;
     }
       else if(phase > 0) {
       if (count < 2) increment = pow(2, count);
                else increment = pow(2, count) + 1;
                data += increment; 
     }
            
      delay(75);
      count++;


      //this code can be optimized, the difference in incrementation can be used to change data each time 256 is reached. 128-64-32-16-8-4-2. I'm in a rush right now I will leave it like this.
      if (data == 256 && phase == 0) {
        data = 129;
        count = 0;
        phase = 1;
      } 
      else if (data == 256 && phase == 1) {
        data = 193;
        count = 0;
        phase = 2;
      }
      else if(data == 256 && phase == 2) {
        data = 225;
        count = 0;
        phase = 3;
      }
      else if(data == 256 && phase == 3) {
        data = 241;
        count = 0;
        phase = 4;
      }
      else if(data == 256 && phase == 4) {
        data = 249;
        count = 0;
        phase = 5;
      }
      else if(data == 256 && phase == 5) {
        data = 253;
        count = 0;
        phase = 6;
      }
      else if(data == 256 && phase == 6) {
        data = 255;
        count = 0;
        phase = 0;
      }
      
    }

    if (type == 3) {

    data = random(256);
    delay(75);
      
    }
  
    if(type == 4) {

    if (count < 7) data = 255;
    if (count > 7) data = 0;  
    if (count == 14) count = 0;
    
    count++;
    delay(1);

    }

    Serial.print("Count is at ");
    Serial.println(count);
    Serial.print("The increment added to data = ");
    Serial.println(increment);
    Serial.print("Data written onto LEDs should be ");
    Serial.println(data);
    Serial.println();

}
