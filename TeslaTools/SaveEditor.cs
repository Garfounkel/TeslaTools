
using System;
using System.Collections.Generic;
using System.IO;

namespace TeslaTools
{
    class SaveEditor
    {
        public bool readOnly = false;
        public int id = 1;
        public int glove = 0;
        public int blink = 0;
        public int suit = 0;
        public int staff = 0;
        public int defeatedBosses = 0;
        public string openBarriers = "262144";
        public string orbsFound = "";
        public int sceneIndex = -1;
        public string checkpointIndex = "0";
        public int timeMultiplier = 1;
        public string blockedAmbiences = "[]";
        public string scenesOnMap = "AQ==";
        public string secretSceneExtensionsOnMap = "";
        public int gameComplete = 0;
        public List<string> sceneList = new List<string>{"Home",
                                                        "Scales",
                                                        "Rooftops",
                                                        "Broken Bridge",
                                                        "Chimneys",
                                                        "Balconies",
                                                        "Stave Church",
                                                        "Moat",
                                                        "Courtyard",
                                                        "Classroom",
                                                        "Levitation",
                                                        "Pistons",
                                                        "Chapel",
                                                        "Barrier",
                                                        "Trials",
                                                        "Well",
                                                        "Thunderbolt",
                                                        "Iron Lice",
                                                        "Magic Carpet",
                                                        "Snakeway",
                                                        "Fernus",
                                                        "Maglev",
                                                        "Hidey Hole",
                                                        "Fernus",
                                                        "Cooling Room",
                                                        "Cages",
                                                        "Magnetflies",
                                                        "Grues",
                                                        "Waterworks",
                                                        "Waterworks",
                                                        "Roots",
                                                        "Act One",
                                                        "Heartwood",
                                                        "Maze",
                                                        "Mural",
                                                        "Ventilation",
                                                        "Faradeus",
                                                        "Shrine",
                                                        "Wintergarden",
                                                        "Wintergarden",
                                                        "Wintergarden",
                                                        "Wintergarden",
                                                        "Wintergarden",
                                                        "Wintergarden",
                                                        "Storage",
                                                        "Act Two",
                                                        "Scrapyard",
                                                        "Crusher",
                                                        "Smelter",
                                                        "Molten Pool",
                                                        "Fireproof",
                                                        "Forge",
                                                        "Licemover",
                                                        "Pipes",
                                                        "Chokepoint",
                                                        "Brazen Bull",
                                                        "Magnetbridge",
                                                        "Guardian",
                                                        "Electromagnets",
                                                        "Clerestory",
                                                        "Oleg",
                                                        "Act Three",
                                                        "Control Room",
                                                        "Wheeltrack",
                                                        "Acrobatics",
                                                        "Race",
                                                        "Feast hall",
                                                        "Happy Ending",
                                                        "Magnetic Lift",
                                                        "Magnetic Ball",
                                                        "Fatal Attraction",
                                                        "Surprise",
                                                        "Alternation",
                                                        "Grand Design",
                                                        "Solomon Tesla",
                                                        "Pinnacle",
                                                        "Guerickes Orb",
                                                        "Dodge This",
                                                        "Deep Down",
                                                        "Hidden Library",
                                                        "Tower",
                                                        "Tanngrisne",
                                                        "Tanngnjost",
                                                        "Bridge",
                                                        "Room",
                                                        "Stormfront",
                                                        "Palace Stairs",
                                                        "Downfall",
                                                        "Passage",
                                                        "Scrolls",
                                                        "Dungeon",
                                                        "Scrolls",
                                                        "Secret Passage",
                                                        "Grand Hall",
                                                        "The King",
                                                        "Cooler",
                                                        "Assembler",
                                                        "Forge",
                                                        "Homage",
                                                        "Crown Space",
                                                        "Home",
                                                        "Scales",
                                                        "Rooftops",
                                                        "Broken Bridge",
                                                        "Chimneys",
                                                        "Balconies",
                                                        "Stave Church",
                                                        "Moat",
                                                        "Tower",
                                                        "Tower",
                                                        "Tower",
                                                        "Tower",
                                                        "Tower",
                                                        "Tower"};

        public List<string> commonSceneList = new List<string>{"Home",
                                                        "Levitation",
                                                        "Fernus",
                                                        "Faradeus",
                                                        "Scrapyard",
                                                        "Crusher",
                                                        "Oleg",
                                                        "Guerickes Orb",
                                                        "The King"};

        public bool WriteSave()
        {
            try
            {
                // Get the relative path
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                              "\\AppData\\LocalLow\\Rain\\Teslagrad\\" + id + "\\SavedGame.asset";

                // Create the directory structure at the given path if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(path));

                if (File.Exists(path))
                    File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly);

                // Create and Write the file with the given values
                using (StreamWriter sw = File.CreateText(path))
                {

                    // Make sure the file is not ReadOnly anymore
                    sw.Write("%YAML 1.1\n%TAG !u! tag:unity3d.com,2011:\n--- !u!114 &11400000\nMonoBehaviour:\n  m_ObjectHideFlags: 0\n  m_PrefabParentObject:\n    fileID: 0\n  m_PrefabInternal:\n    fileID: 0\n  m_GameObject:\n    fileID: 0\n  m_Enabled: 1\n  m_EditorHideFlags: 0\n  m_Script:\n    fileID: 11500000\n    guid: 0cb2af3afcc645843a1dace1a35b4f68\n    type: 1\n  m_Name: SavedGame\n  formatVersion: 1.13\n");

                    sw.WriteLine("  glove: " + glove);
                    sw.WriteLine("  blink: " + blink);
                    sw.WriteLine("  suit: " + suit);
                    sw.WriteLine("  staff: " + staff);
                    sw.WriteLine("  defeatedBosses: " + defeatedBosses);
                    sw.WriteLine("  openBarriers: " + openBarriers);
                    sw.WriteLine("  orbsFound: " + orbsFound);
                    if (sceneIndex != -1)
                        sw.WriteLine("  sceneIndex: " + sceneIndex);
                    sw.WriteLine("  checkpointIndex: " + checkpointIndex);
                    sw.WriteLine("  timeMultiplier: " + timeMultiplier);
                    sw.WriteLine("  blockedAmbiences: " + blockedAmbiences);
                    sw.WriteLine("  scenesOnMap: " + scenesOnMap);
                    sw.WriteLine("  secretSceneExtensionsOnMap: " + secretSceneExtensionsOnMap);
                    sw.WriteLine("  gameComplete: " + gameComplete);
                }

                if (readOnly)
                    File.SetAttributes(path, FileAttributes.ReadOnly);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private int charToInt(char c)
        {
            return c > 'Z' ? c - 'a' + 1 : c - 'A' + 1;
        }
    }
}
