using System;
using System.Windows.Forms;

namespace Minotti
{
    public static class sepad
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            throw new NotImplementedException("Completar arranque según la lógica original del .sra (sin cambiar nombres).");
        }

        //        /* SRA original embebido
        //﻿forward
        //global type sepad from application
        //end type
        //global transaction sqlca
        //global dynamicdescriptionarea sqlda
        //global dynamicstagingarea sqlsa
        //global error error
        //global message message
        //end forward

        //global variables
        //uo_app		guo_app
        //String		gestado
        //Long        gl_Capitulo
        //Long        gl_Rubrica
        //Long        gl_Subrubrica[]
        //String      gs_Capitulo
        //String      gs_Rubrica
        //String      gs_Subrubrica[]

        //end variables


        //global type sepad from application 
        //string appname = "sepad"
        //boolean toolbartext = true
        //string displayname = "Minotti"
        //string appicon = "logo.ico"

        //end type

        //global sepad sepad

        //on sepad.create
        //appname="sepad"
        //message=create message
        //sqlca=create transaction
        //sqlda=create dynamicdescriptionarea
        //sqlsa=create dynamicstagingarea
        //error=create error
        //end on

        //on sepad.destroy
        //destroy(sqlca)
        //destroy(sqlda)
        //destroy(sqlsa)
        //destroy(error)
        //destroy(message)
        //end on

        //event open;/* Crea el objeto con todas las facilidades de la aplicación */
        //        guo_app = CREATE uo_sepad
        //guo_app.Event Trigger ue_Open()


        //end event

        //event close; DESTROY uo_app

        //end event

        //event systemerror; Open(w_system_error)
        //end event

        //        */
        //    }
        //    }




        public class application { }
        public class transaction { }
        public class dynamicdescriptionarea { }
        public class dynamicstagingarea { }
        public class error { }
        public class message { }

        public class uo_app { }
        public partial class uo_sepad : uo_app
        {
            // Event Trigger ue_Open()
            public void ue_Open() { }
        }

        public static class Globals
        {
            public static uo_app guo_app;
            public static string gestado;
            public static long gl_Capitulo;
            public static long gl_Rubrica;
            public static long[] gl_Subrubrica;
            public static string gs_Capitulo;
            public static string gs_Rubrica;
            public static string[] gs_Subrubrica;

            public static transaction sqlca;
            public static dynamicdescriptionarea sqlda;
            public static dynamicstagingarea sqlsa;
            public static error error;
            public static message message;
        }

        // global type sepad from application
        public class sepad_app : application
        {
            public string appname = "sepad";
            public bool toolbartext = true;
            public string displayname = "Minotti";
            public string appicon = "logo.ico";
        }

        // global sepad sepad
        public static class AppInstance
        {
            public static sepad_app sepad = new sepad_app();
        }

        // on sepad.create / destroy / events
        public static class sepad_events
        {
            public static void create()
            {
                AppInstance.sepad.appname = "sepad";
                Globals.message = new message();
                Globals.sqlca = new transaction();
                Globals.sqlda = new dynamicdescriptionarea();
                Globals.sqlsa = new dynamicstagingarea();
                Globals.error = new error();
            }

            public static void destroy()
            {
                Globals.sqlca = null;
                Globals.sqlda = null;
                Globals.sqlsa = null;
                Globals.error = null;
                Globals.message = null;
            }

            public static void open()
            {
                /* Crea el objeto con todas las facilidades de la aplicación */
                Globals.guo_app = new uo_sepad();
                ((uo_sepad)Globals.guo_app).ue_Open(); // guo_app.Event Trigger ue_Open()
            }

            public static void close()
            {
                // DESTROY uo_app
                Globals.guo_app = null;
            }

            public static void systemerror()
            {
                // Open(w_system_error)
            }
        }

        public static class sepad
        {
            [STAThread]
            public static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // on sepad.create
                sepad_events.create();

                try
                {
                    // event open
                    sepad_events.open();

                    // (sin interpretar: no se agrega loop/ventana principal aquí)
                }
                finally
                {
                    // on sepad.destroy
                    sepad_events.destroy();
                }
            }

            /* SRA original embebido (referencia) ...
               (dejar el bloque comentado si querés)
            */
        }

    }



}