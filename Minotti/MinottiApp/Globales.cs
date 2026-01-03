using Minotti.Data;
using Minotti.Views.Pbl.Controls;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minotti
{

    // PB: global dynamicdescriptionarea sqlda
    public class DynamicDescriptionArea
    {
        // Placeholder – completás según lo que uses realmente
    }

    // PB: global dynamicstagingarea sqlsa
    public class DynamicStagingArea
    {
        // Placeholder
    }

    // PB: global error error
    public class ErrorState
    {
        public int number { get; set; }
        public string text { get; set; }
        public string windowmenu { get; set; }
        public string @object { get; set; }
        public string objectevent { get; set; }
        public int line { get; set; }
    }

    // PB: global message message
    public class MessageState
    {
        public string StringParm { get; set; }
        public object PowerObjectParm { get; set; }
    }



    // =========================================================
    // Global variables PB → clase estática
    // =========================================================
    public static class Globales
    {
        // PB: uo_app guo_app
        public static uo_sepad guo_app;

        // PB: String gestado
        public static string gestado;

        // PB: Long gl_Capitulo, gl_Rubrica, gl_Subrubrica[]
        public static long gl_Capitulo;
        public static long gl_Rubrica;
        public static long[] gl_Subrubrica = Array.Empty<long>();

        // PB: String gs_Capitulo, gs_Rubrica, gs_Subrubrica[]
        public static string gs_Capitulo;
        public static string gs_Rubrica;
        public static string[] gs_Subrubrica = Array.Empty<string>();

        // PB: global transaction sqlca
        //public static SQLCA SQLCA = new SQLCA();

        // PB: global dynamicdescriptionarea sqlda
        public static DynamicDescriptionArea SQLDA = new DynamicDescriptionArea();

        // PB: global dynamicstagingarea sqlsa
        public static DynamicStagingArea SQLSA = new DynamicStagingArea();

        // PB: global error error
        public static ErrorState error = new ErrorState();

        // PB: global message message
        public static MessageState message = new MessageState(); 
        public static SQLCAProxy SQLCA { get; } = new();



    }



}
