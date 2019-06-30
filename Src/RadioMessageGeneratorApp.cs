/*
==========================================================================
This file is part of Radio Message Generator, an utility which creates
WAV radio messages using the Windows 7/10 text-to-speech library.

RadioMessageGenerator was created by @akaAgar.
The source code repository is available here: https://github.com/akaAgar/radio-message-generator

Radio Message Generator is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Radio Message Generator is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Radio Message Generator. If not, see https://www.gnu.org/licenses/
==========================================================================
*/

using RadioMessageGenerator.Forms;
using System;
using System.Windows.Forms;

namespace RadioMessageGenerator
{
    /// <summary>
    /// Main class of the application
    /// </summary>
    public sealed class RadioMessageGeneratorApp
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
