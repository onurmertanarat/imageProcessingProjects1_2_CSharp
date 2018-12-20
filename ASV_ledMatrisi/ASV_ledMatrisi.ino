/*
 * Geliştirici: Onur Mert ANARAT | 2013010812004
 * e-mail: anrtonurmert@gmail.com
 * GitHub: github.com/anrtonurmert
 * Üniversite: Karabük Üniversitesi
 * Fakülte: Teknoloji Fakültesi
 * Bölüm: Mekatronik Mühendisliği
 * Dip not: "Görüntü İşleme" dersi için dönem sonu proje ödevi olarak yapılmıştır.
*/
const int ledDizisi[9]={4,5,6,7,8,9,10,11,12};
int data;

void setup()
{
    Serial.begin(9600);
    for(int i=0; i<9;i++)
    {
      pinMode(ledDizisi[i], OUTPUT);
    }
}

void loop()
{
    data= Serial.read();
    if(data=='1')
    {
      digitalWrite(4, HIGH);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
    else if(data=='2')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, HIGH);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
     else if(data=='3')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, HIGH);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
     else if(data=='4')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, HIGH);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
     else if(data=='5')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, HIGH);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
     else if(data=='6')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, HIGH);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
     else if(data=='7')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, HIGH);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
    }
     else if(data=='8')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, HIGH);
      digitalWrite(12, LOW);
    }
     else if(data=='9')
    {
      digitalWrite(4, LOW);
      digitalWrite(5, LOW);
      digitalWrite(6, LOW);
      digitalWrite(7, LOW);
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, HIGH);
    }
}
