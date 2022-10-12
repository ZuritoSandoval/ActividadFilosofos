using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActividadFilosofos
{
    public partial class Form1 : Form
    { 
        //declarar los 5 cubiertos
        public bool cubierto1 = true, cubierto2 = true, cubierto3 = true, cubierto4 = true, cubierto5 = true;
        //declaramos la funcion del semaforo
        public Semaphore sem = new Semaphore(2, 3);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ingresamos los hilos de los personajes y los le damos inicio a los hilos 
            for (int i = 0; i < 5; i++)
            {
            Thread adanco = new Thread(new ThreadStart(adan));
            Thread budaco = new Thread(buda);
            Thread vegetaco = new Thread(vegeta);
            Thread hadesco = new Thread(hades);
            Thread gokuco = new Thread(goku);
            adanco.Start();
            budaco.Start();
            vegetaco.Start();
            hadesco.Start();
            gokuco.Start();
            }
        }
        public void adan()
        {
            //declaramos el semaforo
            sem.WaitOne();
            //declaramos los cubiertos que el personaje va a ocupar
            if (cubierto5 == true && cubierto1 == true) { 
                //declaramos las variables de cubiertos como false 
                cubierto1 = false;
                cubierto5 = false;
                Invoke((Delegate)new Action(() => {
                    //si los palillos no estan ocupados, el personaje los tomara
                    Adan.Visible = false;
                    AdanComiendo.Visible = true;
                }));
                //dormimos el hilo por 5 segundo 
                Thread.Sleep(5000);
            }
            Invoke((Delegate)new Action(() => {
                //cuando acaben los 5 segundos el personaje dejara las variables para que otro personaje las ocupe
                Adan.Visible = true;
                AdanComiendo.Visible = false;
            }));
            cubierto1 = true;
            cubierto2 = true;
            sem.Release();
        }
        //aqui el hilo del personaje tiene las mismas funciones que el anterior, simplemente cambia los palillos que ocupa y los deja
        public void buda()
        {
            sem.WaitOne();
            if (cubierto1 == true && cubierto2 == true)
            {
                cubierto1 = false;
                cubierto2 = false;
                Invoke((Delegate)new Action(() => {
                    Buda.Visible = false;
                    BudaComiendo.Visible = true;
                }));
                Thread.Sleep(5000);
            }
            Invoke((Delegate)new Action(() => {
                Buda.Visible = true;
                BudaComiendo.Visible = false;
            }));
            cubierto2 = true;
            cubierto3 = true;
            sem.Release();
        }
        //aqui el hilo del personaje tiene las mismas funciones que el anterior, simplemente cambia los palillos que ocupa y los deja
        public void vegeta()
        {
            sem.WaitOne();
            if (cubierto2 == true && cubierto3 == true)
            {
                cubierto2 = false;
                cubierto3 = false;
                Invoke((Delegate)new Action(() => {
                    Vegeta.Visible = false;
                    VegetaComiendo.Visible = true;
                }));
                Thread.Sleep(5000);
            }
            Invoke((Delegate)new Action(() => {
                Vegeta.Visible = true;
                VegetaComiendo.Visible = false;
            }));
            cubierto3 = true;
            cubierto4 = true;
            sem.Release();
        }
        //aqui el hilo del personaje tiene las mismas funciones que el anterior, simplemente cambia los palillos que ocupa y los deja
        public void hades()
        {
            sem.WaitOne();
            if (cubierto3 == true && cubierto4 == true)
            {
                cubierto3 = false;
                cubierto4 = false;
                Invoke((Delegate)new Action(() => {
                    Hades.Visible = false;
                    HadesComiendo.Visible = true;
                }));
                Thread.Sleep(5000);
            }
            Invoke((Delegate)new Action(() => {
                Hades.Visible = true;
                HadesComiendo.Visible = false;
            }));
            cubierto4 = true;
            cubierto5 = true;
            sem.Release();
        }
        //aqui el hilo del personaje tiene las mismas funciones que el anterior, simplemente cambia los palillos que ocupa y los deja
        public void goku()
        {
            sem.WaitOne();
            if (cubierto4 == true && cubierto5 == true)
            {
                cubierto4 = false;
                cubierto5 = false;
                Invoke((Delegate)new Action(() => {
                    Goku.Visible = false;
                    GokuComiendo.Visible = true;
                }));
                Thread.Sleep(5000);
            }
            Invoke((Delegate)new Action(() => {
                Goku.Visible = true;
                GokuComiendo.Visible = false;
            }));
            cubierto5 = true;
            cubierto1 = true;
            sem.Release();
        }
    }
}
