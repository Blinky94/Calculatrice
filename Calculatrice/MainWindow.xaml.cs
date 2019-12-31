using Calculatrice.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculatrice
{

    public partial class MainWindow : Window
    {

        #region Fields

        private List<string> mListOfFormulas = new List<string>();
        private string mRegexRulesLineBreak = @"(?:\r\n|\n\r|\t|\r|\n)";
        private string mOperators = @"+-×÷.";
        private string mRegexOperators = @"(?:\+|\-|\×|\÷)";
        private string mParenthese = @"()";
        // private string mRegexParenthese = @"(?:\(|\))";
        private bool mRacine = false;

        #endregion

        private string Calculate()
        {
            // Appel de l'API de calculs ici
            return "100";
        }

        private bool IsCurrentCharInTheList(string pSpecialChars, char pChar)
        {
            return pSpecialChars.ToCharArray().Any(x => x == pChar);
        }

        private Run StylizedNewRun(string pChar, SolidColorBrush pColor, bool pIsSqrt = false)
        {
            var lRun = new Run(pChar);
            lRun.Foreground = pColor;

            if (pIsSqrt)
            {
                TextDecoration lOverline = new TextDecoration();
                lOverline.Location = TextDecorationLocation.OverLine;
                lOverline.Pen = new Pen(Brushes.Black, 1);
                lOverline.PenThicknessUnit = TextDecorationUnit.FontRecommended;
                TextDecorationCollection myCollection = new TextDecorationCollection();
                lRun.TextDecorations.Add(lOverline);
            }

            return lRun;
        }
        private Paragraph ColorizeParagraph(ref string pText)
        {
            var lParagraph = new Paragraph();
            bool lIsSqrt = false;

            foreach (var lChar in pText)
            {
                if (IsCurrentCharInTheList(mParenthese, lChar))
                    lParagraph.Inlines.Add(StylizedNewRun(lChar.ToString(), Brushes.Red, lIsSqrt));
                else if (IsCurrentCharInTheList(mOperators, lChar))
                    lParagraph.Inlines.Add(StylizedNewRun(lChar.ToString(), Brushes.Green, lIsSqrt));
                else if (lChar == '√')
                {
                    lParagraph.Inlines.Add(StylizedNewRun(lChar.ToString(), Brushes.Black));
                    lIsSqrt = true;
                }
                else if (lChar == '|')
                {
                    lParagraph.Inlines.Add(StylizedNewRun(lChar.ToString(), Brushes.Transparent));
                    lIsSqrt = false;
                    mRacine = false;
                }
                else
                    lParagraph.Inlines.Add(StylizedNewRun(lChar.ToString(), Brushes.Black, lIsSqrt));
            }

            return lParagraph;
        }

        private void MoveCustomCaret()
        {
            var lTextPointer = new TextRange(NumericDisplay.ContentStart, NumericDisplay.ContentEnd).End;
            var lRect = lTextPointer.GetCharacterRect(LogicalDirection.Forward);

            var lCaretLocationX = lRect.X;
            var lCaretLocationY = lRect.Y;

            if (!double.IsInfinity(lCaretLocationX))
                Canvas.SetLeft(Caret, lCaretLocationX);

            if (!double.IsInfinity(lCaretLocationY))
                Canvas.SetTop(Caret, lCaretLocationY);
        }

        private void DeleteBreakLineChar(ref string pText, char pChar = default)
        {
            pText = pChar == '1' || pChar == 'I' ? string.Join(" ", Regex.Split(pText, mRegexRulesLineBreak)) : string.Join(string.Empty, Regex.Split(pText, mRegexRulesLineBreak));
        }

        /// <summary>
        /// Rajoute un espace si le charactere est '1' et supprime les caracteres de retour à la ligne
        /// </summary>
        /// <param name="pChar"></param>
        /// <returns></returns>
        private string GetFormatedTextFromDisplay(char pChar = default)
        {
            var lText = new TextRange(NumericDisplay.ContentStart, NumericDisplay.ContentEnd).Text;
            DeleteBreakLineChar(ref lText, pChar);

            return lText;
        }

        private void AddToParagraph(char pChar)
        {
            string lText = GetFormatedTextFromDisplay(pChar);

            if (lText.Length > 0)
            {
                // Remplace le 1er caractere si '0' par un numérique si est digit ou parenthese ouvrante ou alphabetique
                if ((Char.IsDigit(pChar) || IsCurrentCharInTheList(mParenthese, pChar) || Char.IsLetter(pChar) || pChar == 'π' || pChar == '√') && lText == "0")
                    lText = string.Empty;

                // Interdire le signe - s'il n'y a pas de nombre avant
                if (IsCurrentCharInTheList(mOperators, pChar) && lText == "0")
                    return;

                // Test si dernier caractere différent de ['+','-','*','/']
                if (IsCurrentCharInTheList(mOperators, pChar) && IsCurrentCharInTheList(mOperators, lText.LastOrDefault()))
                    return;

                // Empêche le point d'être saisi 2 fois sur le même nombre
                if (Regex.Split(lText, mRegexOperators).LastOrDefault().Contains(".") && pChar == '.')
                    return;

                // Interdire la parenthèse ouvrante après un nombre
                if (Char.IsDigit(lText.LastOrDefault()) && pChar == '(')
                    return;

                // Interdire la parenthèse ouvrante après un point
                if (lText.LastOrDefault() == '.' && pChar == '(')
                    return;

                // Interdire la parenthese fermante si le dernier caractere est un opérateur
                if ((IsCurrentCharInTheList(mOperators, lText.LastOrDefault()) && pChar == ')'))
                    return;

                // Interdire le point si le dernier caractere est une parenthèse fermante
                if (lText.LastOrDefault() == ')' && pChar == '.')
                    return;

                // Interdire le point après les parentheses
                if ((lText.LastOrDefault() == '(') && (IsCurrentCharInTheList(mOperators, pChar)))
                    return;

                // Interdire les caracteres alphanumerics
                if (IsCurrentCharInTheList(")", lText.LastOrDefault()) && !IsCurrentCharInTheList(mOperators, pChar) && pChar != '|')
                    return;

                // Interdire la parenthèse fermante si pas de parenthese ouvrante avant, et fiabilise l'égalité du nombre de parenthèses ouvrantes et fermantes
                if (lText.Count(x => x == '(') == lText.Count(x => x == ')') && pChar == ')')
                    return;

                // Interdire la parenthèse fermante si dernier caractere est parenthese ouvrante (parentheses vides)
                if (IsCurrentCharInTheList("(", lText.LastOrDefault()) && pChar == ')')
                    return;

                // Interdire tout opérateurs après une parenthese ouvrante, sauf le signe '-'
                if (IsCurrentCharInTheList("(", lText.LastOrDefault()) && (pChar != '-' || !Char.IsDigit(pChar) || pChar != '√'))
                    return;

                // Interdire la racine si racine déjà présente
                if (mRacine && pChar == '√')
                    return;

                // Interdire le caractere de fermeture d'une racine s'il n'y a pas de racine active
                if (!mRacine && pChar == '|')
                    return;

                // Interdire la saisie de la racine si le caractere précédent n'est pas un opérateur
                if (pChar == '√' && (!IsCurrentCharInTheList(mOperators, pChar) && lText.LastOrDefault() != '('))
                    return;

                // Interdire la saisie autre qu'un digit ou une parenthèse ouvrante après le caractere racine
                if ((!Char.IsDigit(pChar) || pChar != '(') && lText.LastOrDefault() == '√')
                    return;

            }
            else
            {
                if (IsCurrentCharInTheList(mOperators, pChar))
                    return;
            }


            NumericDisplay.Blocks.Clear();

            lText += pChar;

            NumericDisplay.Blocks.Add(ColorizeParagraph(ref lText));

            MoveCustomCaret();

            // TODO: Ajouter les autres touches saisissables
            // TODO: Switcher entre 2nde et Alpha et être capable de saisir le caractere correspondant
            // TODO: Développer la touche Entrer et afficher le résultat à droite précédé du signe égale
            // TODO: Interdire la parenthese fermante si pas de parenthese ouvrante dans le texte et au début si la première valeur est zero
            // TODO: Interdire certains caracteres à côté d'autres :
            // - Signe multiplier/diviser après une parenthèse ouvrante
            // - Signe ['+','-','*','/''.'] avant une parenthèse fermante
            // - Signe ['+','-','*','/''.'] après une racine carrée
            // TODO: Pouvoir avancer dans le texte lorsqu'on dépasse les 8 lignes
            // TODO: Pouvoir se déplacer en haut, en bas, à gauche, à droite avec les fleches directionnelles dans les formules
        }

        public MainWindow()
        {
            InitializeComponent();

            AddToParagraph('0');
            this.NumericDisplay.LostFocus += (sender, e) => Caret.Visibility = Visibility.Collapsed;
            this.NumericDisplay.GotFocus += (sender, e) => Caret.Visibility = Visibility.Visible;

            RosaryControl.OnDirectionalClicked += OnRosaryControlLeft_Click;
            RosaryControl.OnDirectionalClicked += OnRosaryControlUp_Click;
            RosaryControl.OnDirectionalClicked += OnRosaryControlRight_Click;
            RosaryControl.OnDirectionalClicked += OnRosaryControlDown_Click;
        }

        private void OnRosaryControlDown_Click(object sender, OnDirectionalClickedEventArgs e)
        {
            var lTempSender = sender as RosaryControl;
            var lName = e.DirectionalName;
            if (e.DirectionalName == "DirectionalDown")
            {

            }
        }

        private void OnRosaryControlRight_Click(object sender, OnDirectionalClickedEventArgs e)
        {
            var lTempSender = sender as RosaryControl;
            var lName = e.DirectionalName;
            if (e.DirectionalName == "DirectionalRight")
            {
                //lTempSender.DirectionalRight.Background = Brushes.Red;
                AddToParagraph('|');
            }
        }

        private void OnRosaryControlUp_Click(object sender, OnDirectionalClickedEventArgs e)
        {
            var lTempSender = sender as RosaryControl;
            var lName = e.DirectionalName;
            if (e.DirectionalName == "DirectionalUp")
            {

            }
        }

        private void OnRosaryControlLeft_Click(object sender, OnDirectionalClickedEventArgs e)
        {
            var lTempSender = sender as RosaryControl;
            var lName = e.DirectionalName;
            if (e.DirectionalName == "DirectionalLeft")
            {

            }
        }

        #region Bouger la calculatrice

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.Opacity = 0.75F;
            base.OnMouseLeftButtonDown(e);
            // Begin dragging the window
            this.DragMove();
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            this.Opacity = 1F;
            base.OnMouseLeftButtonUp(e);
        }

        #endregion

        private void Alpha_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            snde.FuncButtonIsChecked = false;
        }

        private void Snde_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            alpha.FuncButtonIsChecked = false;
        }

        private void Sept_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // Un
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('O');
            else
                AddToParagraph('7');
        }

        private void Huit_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // Vn
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('P');
            else
                AddToParagraph('8');
        }

        private void Neuf_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // Wn
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('Q');
            else
                AddToParagraph('9');
        }

        private void Quatre_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L4
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('T');
            else
                AddToParagraph('4');
        }

        private void Cinq_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L5
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('U');
            else
                AddToParagraph('5');
        }

        private void Six_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L6
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('V');
            else
                AddToParagraph('6');
        }

        private void Un_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L1
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('Y');
            else
                AddToParagraph('1');
        }

        private void Deux_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L2
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('Z');
            else
                AddToParagraph('2');
        }

        private void Trois_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L3
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('Θ');
            else
                AddToParagraph('3');
        }

        private void Zero_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // catalog
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph(' ');
            }
            else
                AddToParagraph('0');
        }

        private void Point_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // i : information
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph(':');
            else
                AddToParagraph('.');
        }

        private void Enter_ToggleButtonClick(object sender, RoutedEventArgs e)
        {

            //FillEcranCalculGrapheContent(Calculate(), true);
        }

        private void Multiplier_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                AddToParagraph('[');
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('R');
            else
                AddToParagraph('×'); // #0215
        }

        private void Diviser_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                AddToParagraph('e');
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('M');
            else
                AddToParagraph('÷'); // #0247
        }

        private void Plus_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // mém
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('"');
            else
                AddToParagraph('+'); // #043
        }

        private void Moins_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                AddToParagraph(']');
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('W');
            else
                AddToParagraph('-'); // #045
        }

        private void K_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                AddToParagraph('{');
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('K');
            else
                AddToParagraph('(');
        }

        private void L_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                AddToParagraph('}');
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('L');
            else
                AddToParagraph(')');
        }

        private void H_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (alpha.FuncButtonIsChecked)
                AddToParagraph('H');
            else
                AddToParagraph('^');
        }

        private void I_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                AddToParagraph('√');
                mRacine = true;
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('I');
            else
            {
                // Calcul la racine carrée du nombre ou de l'expression saisie
            }
        }

        private void Log_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // 10exp(x)
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('N');
            else
            {
                // log
            }
        }

        private void Ln_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // e(x)
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('S');
            else
            {
                // ln
            }
        }

        private void Sto_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // Rappel
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('X');
            else
            {
                // Sto-->
            }

        }

        private void J_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // EE
            }
            else if (alpha.FuncButtonIsChecked)
                AddToParagraph('J');
            else
                AddToParagraph(',');
        }

        private void Rep_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // rep
            }
            else if (alpha.FuncButtonIsChecked)
            {
                // ?
            }
            else
            {
                AddToParagraph('˗'); // (-)
            }
        }

        private void On_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // off
            }
            else
            {
                // on
            }
        }

        private void GraphStats_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // graph stats
            }
            else if (alpha.FuncButtonIsChecked)
            {
                // f1
            }
            else
            {
                // f(x)
            }
        }

        private void DefTable_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // def table
            }
            else if (alpha.FuncButtonIsChecked)
            {
                // f2
            }
            else
            {
                // fenetre
            }
        }

        private void Format_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // format
            }
            else if (alpha.FuncButtonIsChecked)
            {
                // f3
            }
            else
            {
                // zoom
            }
        }

        private void Calculs_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // calculs
            }
            else if (alpha.FuncButtonIsChecked)
            {
                // f4
            }
            else
            {
                // trace
            }
        }

        private void Table_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // table
            }
            else if (alpha.FuncButtonIsChecked)
            {
                // f5
            }
            else
            {
                // graphe
            }
        }

        private void Quitter_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // quitter
            }
            else
            {
                // mode
            }
        }

        private void Inserer_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // insérer
            }
            else
            {
                // suppr
            }
        }

        private void Echanger_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // échanger
            }
            else
            {
                // X,T,teta,n
            }
        }

        private void Listes_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // listes
            }
            else
            {
                // stats
            }
        }

        private void Math_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // tests
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('A');
            }
            else
            {
                // math
            }
        }

        private void Matrice_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // x exp(-1)
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('B');
            }
            else
            {
                // matrice
            }
        }

        private void Dessin_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // dessin
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('C');
            }
            else
            {
                // prgm
            }
        }

        private void Distrib_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // distrib
            }
            else
            {
                // var
            }
        }

        private void Annul_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            // annul

            string lText = GetFormatedTextFromDisplay();

            if (lText.Length > 0)
                lText = lText.Substring(0, lText.Length - 1);

            NumericDisplay.Blocks.Clear();
            NumericDisplay.Blocks.Add(ColorizeParagraph(ref lText));
            MoveCustomCaret();
        }

        private void Angle_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // angle
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('D');
            }
            else
            {
                // ◄►
            }
        }

        private void Trig_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                AddToParagraph('π');
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('E');
            }
            else
            {
                // trig
            }
        }

        private void Resol_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // apps
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('F');
            }
            else
            {
                // résol
            }
        }

        private void G_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // ∫:□d□►
            }
            else if (alpha.FuncButtonIsChecked)
            {
                AddToParagraph('G');
            }
            else
            {
                // ▀∕▄
            }
        }
    }
}
