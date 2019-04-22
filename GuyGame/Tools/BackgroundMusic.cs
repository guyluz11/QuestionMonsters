using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;

namespace GuyGame
{
    public class BackgroundMusic
    {
        
        private SoundPlayer player; // store the player for the music

        public BackgroundMusic()
        {
            SetBackgroundMusic();
        }
        
        
        
        private void SetBackgroundMusic()
        {
                        
            var rand = new Random();

            string musicFileLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\..\..\Resources\Music\" ;    // Location of the file in the specific computer

            var allSongNames = FileNames(musicFileLocation);    // List of all songs file names
            
            var randomSongNumberInList = rand.Next(allSongNames.Count);    // stores the rand string number from the list
            var randomSongFromTheList = allSongNames[randomSongNumberInList]; // Create the variable to save all the text and insert random string from the list
            
            musicFileLocation += randomSongFromTheList; 
            try
            {
                player = new SoundPlayer(musicFileLocation);    // Create new sound player with the music file
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot initialize music Error:");
                Console.WriteLine(e);
                throw;
            }
            PlayBackgroundMusic();
        }

        private void PlayBackgroundMusic()
        {
            try
            {
                player.Play();    // Start playing the Music
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot play music file Error:");
                Console.WriteLine(e);
                throw;
            }
        }
        
        private List<String> FileNames(string sDir)    // get dir and return all files names in dir
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    string fileName = f.Substring(f.LastIndexOf('\\')+1);
                    files.Add(fileName);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(FileNames(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }
        
    }
}