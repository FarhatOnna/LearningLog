//  Main Author: Kyle Chapman
//  Editor : Farhat Rahman
//  Created: November 1st 2024
//  Updated: November 2024
//  Description: 
//  Represents an entry in a learning log program with properties for
//  Notes on the entry, a state of wellness, a state of quality,
//  as well as a file to recording.

using System;
//
using System.Buffers.Text;
//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Windows.Controls;
//
using System.Windows;
using System.Xml.Linq;

namespace LearningLog
{
    internal class LogEntry
    {
        #region "Variables declarations"
        //static variables
        private static int count = 0;
        private static DateTime firstEntry;
        private static DateTime newsEntry;

        //Instance variables
        private int logId;
        private DateTime logDate = DateTime.Now;
        private int logWellness;
        private int logQuality;
        private string logNotes = String.Empty;
        private FileInfo logFile;

        #endregion


        #region "Constructors"
        /// <summary>
        /// Default constructor sets the count and id values
        /// </summary>
        public LogEntry()
        {
            count++;
            logId = count;
        }

        /// <summary>
        /// Parametarized constructor to create a new log entry object
        /// </summary>
        /// <param name="wellnessValue"> A wellness value between 1 and 5</param>
        /// <param name="qualityValue"> A quality value between 1 and 5</param>
        /// <param name="notesValue"> Notes for this log entry</param>
        /// <param name="fileValue"> File path to the associated recording file</param>

        public LogEntry(int wellnessValue, int qualityValue, string notesValue, FileInfo fileValue)
        {
            // Update the static variables
            count++;
            if (count == 0)
            {
                firstEntry = DateTime.Now;

            }
            newsEntry = DateTime.Now;

            // Set values for the instance properties.
            logId = count;
            Wellness = wellnessValue;
            Quality = qualityValue; 
            Notes = notesValue;
            RecordingFile = fileValue;
        }
        #endregion

        #region "Properties"
        /// <summary>
        /// Sets or accesses the log's unique identifier
        /// </summary>
        public int Id { get => logId; private set
            {
                logId = value;
            }
        }

        /// <summary>
        /// Date indicating when the audio was recorded accessed
        /// </summary>

        public DateTime EntryDate { get => logDate; set { logDate = value; } }

        /// <summary>
        /// Number based in the "Wellness/Mood" ComboBox;
        /// </summary>
        public int Wellness { get => logWellness; set { logWellness = value; } }

        /// <summary>
        /// Number based in the "Quality" ComboBox;
        /// </summary>
        public int Quality { get => logQuality; set { logQuality = value; } }

        /// <summary>
        /// Piece of text from the "notes" TextBox; notes about the log entry.
        /// </summary>
        public string Notes 
        { 
            get => logNotes; 
            set 
            { 
                if (value.Trim().Length > 0)
                {
                    logNotes = value;
                }
                else
                {
                    MessageBox.Show("The notes have been left blank.", "Entry Error");
                }
                
                logNotes = value; 
            } 
        
        }

        /// <summary>
        /// Notes the file location of the audio file for the log entry.
        /// </summary>
        public FileInfo RecordingFile {  get => logFile; set { logFile = value; } }

        /// <summary>
        /// Get the total number of log entries.
        /// </summary>
        public static int Count => count;

        /// <summary>
        /// Get the first log entry's date
        /// </summary>
        public static DateTime FirstEntry => firstEntry;

        /// <summary>
        /// Get the recent log entry's date
        /// </summary>
        public static DateTime NewsEntry => newsEntry;

        #endregion

        #region "Methods"
        /// <summary>
        /// Displays a log entry as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Entry " + Id + " created at" + EntryDate.ToString();
        }

        #endregion
    }
}
