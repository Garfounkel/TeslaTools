using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TeslaTools
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private SaveEditor se;
        private Bingo bi;
        private Brush defaultButtonBrush;
        private Brush targetButtonBrush = Brushes.MediumTurquoise;

        public MainWindow()
        {
            se = new SaveEditor();
            bi = new Bingo();

            InitializeComponent();

            // SaveEditor Stuffs
            SceneIndex_LB.ItemsSource = se.commonSceneList;
            LogTextBox.Text = "";

            // Bingo Stuffs
            Seed_TB.Text = bi.GetRandomSeed();
            defaultButtonBrush = Bingo_B_11.Background;
            GenerateBingoCard_Click(null, null);
        }

        #region SaveEditor
        private void CreateFile_Click(object sender, RoutedEventArgs e)
        {
            SetSavefileId();
            SetDefeatedBosses();
            SetItems();
            SetScrollNumber();
            se.readOnly = (bool)ReadOnly_CB.IsChecked;
            se.gameComplete = 0;
            if ((bool)Hide_CB.IsChecked)
                se.sceneIndex = se.sceneList.IndexOf((string)SceneIndex_LB.SelectedValue);
            else
                se.sceneIndex = SceneIndex_LB.SelectedIndex;
            Console.WriteLine(se.sceneIndex);

            if (se.WriteSave())
                LogTextBox.Text = "New file succesfully created !";
            else
                LogTextBox.Text = "A problem occured while writing the file. =(\nYou can try to delete the file manually.";
        }

        private void SetSavefileId()
        {
            se.id = (bool)Savefile1_RB.IsChecked ? 1 : se.id;
            se.id = (bool)Savefile2_RB.IsChecked ? 2 : se.id;
            se.id = (bool)Savefile3_RB.IsChecked ? 3 : se.id;
            se.id = (bool)Savefile4_RB.IsChecked ? 4 : se.id;
            se.id = (bool)Savefile5_RB.IsChecked ? 5 : se.id;
            se.id = (bool)Savefile6_RB.IsChecked ? 6 : se.id;

            Console.WriteLine("File id: " + se.id);
        }

        private void SetDefeatedBosses()
        {
            int tmp = 0;
            tmp |= (bool)Fernus_CB.IsChecked ? 1 : 0;
            tmp |= (bool)Faradeus_CB.IsChecked ? 2 : 0;
            tmp |= (bool)Oleg_CB.IsChecked ? 4 : 0;
            tmp |= (bool)Orb_CB.IsChecked ? 8 : 0;
            se.defeatedBosses = tmp;

            Console.WriteLine("DefeatedBosses: " + se.defeatedBosses);
        }

        private void SetItems()
        {
            se.glove = (bool)Gloves_CB.IsChecked ? 1 : 0;
            se.blink = (bool)Blink_CB.IsChecked ? 1 : 0;
            se.suit = (bool)Cloak_CB.IsChecked ? 1 : 0;
            se.staff = (bool)Staff_CB.IsChecked ? 1 : 0;
        }

        private void SetScrollNumber()
        {
            se.orbsFound = (bool)Scroll_RB_15.IsChecked ? "NosB4Ac=" : "";
            se.orbsFound = (bool)Scroll_RB_36.IsChecked ? "/////w8=" : se.orbsFound;
        }

        private void NGPlus_Click(object sender, RoutedEventArgs e)
        {
            SetSavefileId();
            se.readOnly = (bool)ReadOnly_CB.IsChecked;

            se.glove = 1;
            se.blink = 1;
            se.suit = 1;
            se.staff = 1;
            se.defeatedBosses = 0;
            se.openBarriers = "0";
            se.orbsFound = "";
            se.checkpointIndex = "0";
            se.timeMultiplier = 1;
            se.blockedAmbiences =
                "\n  - Glove Pickup\n  - 192165520\n  - Blink Pickup\n  - Suit Pickup\n  - 1701365559\n  - 1841440093\n  - 1153593479";
            se.scenesOnMap = "////zf////9////v9w8=";
            se.secretSceneExtensionsOnMap = "AAAIACAAEQAAAg==";
            se.gameComplete = 1;


            if (se.WriteSave())
                LogTextBox.Text = "NG+ file succesfully created !";
            else
                LogTextBox.Text = "A problem occured while writing the file. =(\nYou can try to delete the file manually.";
        }

        private void Hide_CB_Checked(object sender, RoutedEventArgs e)
        {
            SceneIndex_LB.ItemsSource = se.commonSceneList;
        }

        private void Hide_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            SceneIndex_LB.ItemsSource = se.sceneList;
        }
        #endregion

        #region Bingo
        private void ChangeSeed_B_Click(object sender, RoutedEventArgs e)
        {
            Seed_TB.Text = bi.GetRandomSeed();
        }

        private void Bingo_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;

                if (b.Background == targetButtonBrush)
                    b.Background = defaultButtonBrush;
                else
                    b.Background = targetButtonBrush;
            }
        }

        private void GenerateBingoCard_Click(object sender, RoutedEventArgs e)
        {
            bi.StringSeed = Seed_TB.Text;
            bi.SetSeed();
            bi.GenerateBingoCard();

            Bingo_B_11.Content = bi.GetScrollsAt(0, 0);
            Bingo_B_12.Content = bi.GetScrollsAt(0, 1);
            Bingo_B_13.Content = bi.GetScrollsAt(0, 2);
            Bingo_B_14.Content = bi.GetScrollsAt(0, 3);
            Bingo_B_15.Content = bi.GetScrollsAt(0, 4);

            Bingo_B_21.Content = bi.GetScrollsAt(1, 0);
            Bingo_B_22.Content = bi.GetScrollsAt(1, 1);
            Bingo_B_23.Content = bi.GetScrollsAt(1, 2);
            Bingo_B_24.Content = bi.GetScrollsAt(1, 3);
            Bingo_B_25.Content = bi.GetScrollsAt(1, 4);

            Bingo_B_31.Content = bi.GetScrollsAt(2, 0);
            Bingo_B_32.Content = bi.GetScrollsAt(2, 1);
            Bingo_B_33.Content = bi.GetScrollsAt(2, 2);
            Bingo_B_34.Content = bi.GetScrollsAt(2, 3);
            Bingo_B_35.Content = bi.GetScrollsAt(2, 4);

            Bingo_B_41.Content = bi.GetScrollsAt(3, 0);
            Bingo_B_42.Content = bi.GetScrollsAt(3, 1);
            Bingo_B_43.Content = bi.GetScrollsAt(3, 2);
            Bingo_B_44.Content = bi.GetScrollsAt(3, 3);
            Bingo_B_45.Content = bi.GetScrollsAt(3, 4);

            Bingo_B_51.Content = bi.GetScrollsAt(4, 0);
            Bingo_B_52.Content = bi.GetScrollsAt(4, 1);
            Bingo_B_53.Content = bi.GetScrollsAt(4, 2);
            Bingo_B_54.Content = bi.GetScrollsAt(4, 3);
            Bingo_B_55.Content = bi.GetScrollsAt(4, 4);
        }
        #endregion
    }
}
