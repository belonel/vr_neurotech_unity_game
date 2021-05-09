#include <math.h>

void setup() {
  Serial.begin(9600);
  //Serial.println("Minute\tTemperature");
}

void loop() {
  float v = analogRead(A0);
  Serial.flush();
  Serial.println(v);
  //delay(100);
}
