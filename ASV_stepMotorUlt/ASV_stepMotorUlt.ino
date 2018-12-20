/*
 * Geliştirici: Onur Mert ANARAT | 2013010812004
 * e-mail: anrtonurmert@gmail.com
 * GitHub: github.com/anrtonurmert
 * Üniversite: Karabük Üniversitesi
 * Fakülte: Teknoloji Fakültesi
 * Bölüm: Mekatronik Mühendisliği
 * Dip not: "Görüntü İşleme" dersi için dönem sonu proje ödevi olarak yapılmıştır.
*/
int konum, bekleme, serialVal, mapVal, tempVal, posVal, negVal;

void setup() 
{
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT); 
  Serial.begin(9600);
  stepDurdur();
  konum=8;
  bekleme=50;
  tempVal=0;
}

void loop() 
{
  if(Serial.available())
  {
    serialVal=Serial.read();
    //serialVal=Serial.parseInt();
    mapVal=map(serialVal, 0, 600, 0, 2048);
    if(mapVal>tempVal)
    {
      posVal=mapVal-tempVal;
      sagaDon(posVal);
      tempVal=posVal;
      Serial.println(posVal);
    }
    else if(mapVal<tempVal)
    {
      negVal=tempVal-mapVal;
      solaDon(negVal);
      tempVal=negVal;
      Serial.println(negVal);
    }
    else
    {
      stepDurdur();
    }
  }
}

void sagaDon(int adim)
{
  for(int i=0;i<adim;i++)
  {
    digitalWrite(konum, HIGH);
    delay(bekleme);
    digitalWrite(konum, LOW);
    konumArttir();
  }
}

void solaDon(int adim)
{
  for(int i=0;i<adim;i++)
  {
    digitalWrite(konum, HIGH);
    delay(bekleme);
    digitalWrite(konum, LOW);
    konumAzalt();
  }
}

void konumArttir()
{
  konum++;
  if(konum==12) konum=8;  
}

void konumAzalt()
{
  konum--;
  if(konum==7) konum=11;
}

void stepDurdur()
{
  digitalWrite(8, LOW);
  digitalWrite(9, LOW);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);
}
