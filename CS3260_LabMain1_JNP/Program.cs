// Project Prolog
// Name: Josh Parker
// CS3260 Section 001
// Project: Lab_01
// Date: 10/19/2018 11:53:57 PM
// Purpose: This project provides a graphical form for inputting data about employees of a company.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------
using System;
using System.Windows.Forms;

namespace CS3260_LabMain1_JNP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
