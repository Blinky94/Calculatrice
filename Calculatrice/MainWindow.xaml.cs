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

        private string mRegexRuleLineBreak = @"(?:\r\n|\n\r|\t|\r|\n)";
        private string mOperators = @"+-×÷.";


        // private string mRegexParenthese = @"(?:\(|\))";
        private bool mRacine = false;

        private string mRegexMathFunc = @"\+|\-|\×|\÷";
        private string mRegexScience = @"\log|\ln|\X²|\sto→";
        private string mRegexNumerics = @"[0-9]";
        private string mRegexOpenBracket = @"\(";
        private string mRegexCloseBracket = @"\)";
        private string mRegexNumericDot = @"\.";
        private string mRegexMinus = @"\-";
        private string mRegexSquare = @"\√";
        private string mRegexExp10N = @"\10ⁿ";
        private string mRegexEExpN = @"\℮ⁿ";

        private string mRegexRuleNumericBefore = @"(?:[0-9]|\.|\(|\)|\√|\-|\+|\-|\×|\÷";
        private string mRegexRuleNumericAfter = @"(?:[0-9]|\.|\(|\)|\√|\-|\+|\-|\×|\÷";

        //public string Fx { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string GraphStats { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string F1 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Fenetre { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string DefTable { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string F2 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Zoom { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Format { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string F3 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Trace { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Calculs { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string F4 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Graphe { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Table { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string F5 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Snde { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Mode { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Quitter { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Suppr { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Inserer { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Alpha { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string VerrA { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string XTOn { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Echanger { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Stats { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Listes { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Math { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Tests { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _A { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Matrice { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string XExpMoins1 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _B { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Prgm { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Dessin { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _C { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Var { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Distrib { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Annul { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Gauche_Droite { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Angle { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _D { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Trig { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Pi { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _E { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Resol { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Apps { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _F { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Carre_Divise_Carre { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _G { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Chapeau { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _H { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string X2 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Racine { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _I { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Virgule { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string EE { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _J { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Parenthese_Ouvrante { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Accolade_Ouvrante { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _K { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Parenthese_Fermante { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Accolade_Fermante { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _L { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Diviser { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Petit_e { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _M { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Log { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string DixExpX { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _N { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        private string _sept;
        public string _Sept { get { return _sept; } protected set { _sept = sept.FuncText; } }

        //public string UDeN { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _O { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Huit { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string VDeN { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _P { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Neuf { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string WDeN { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _Q { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Multiplier { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Crochet_Ouvrant { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _R { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Ln { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string EExpX { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _S { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Quatre { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string L4 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _T { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Cinq { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string L5 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _U { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Six { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string L6 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _V { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Moins { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Crochet_Fermant { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _W { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string STO { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Rappel { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _X { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Un { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string L1 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _Y { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Deux { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string L2 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string _Z { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Trois { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string L3 { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Teta { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string On { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Off { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Zero { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Catalog { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Espace { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Point { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Petit_i { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Deux_Point { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Moins_Numeric { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Rep { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Interrogation { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Entrer { get { return Fx; } protected set { Fx = graphStats.FuncText; } }
        //public string Preced { get { return Fx; } protected set { Fx = graphStats.FuncText; } }

        #endregion

        /// <summary>
        /// Récupère tous les symboles de toutes les touches de la calculatrice chargés depuis le xml, et attribut une variable à chacun
        /// </summary>
        private void GetAllSymbols()
        {
            
        }


        private string Calculate()
        {
            // Appel de l'API de calculs ici
            return "100";
        }

        private bool IsAuthorizedChars(string pSpecialChars, char pChar)
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
        private Paragraph ColorizeParagraph(string pFormula)
        {
            var lParagraph = new Paragraph();
            bool lIsSqrt = false;

            foreach (var lChar in pFormula)
            {
                if (IsAuthorizedChars(mRegexOpenBracket + mRegexCloseBracket, lChar))
                    lParagraph.Inlines.Add(StylizedNewRun(lChar.ToString(), Brushes.Red, lIsSqrt));
                else if (IsAuthorizedChars(mOperators, lChar))
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

        private void MoveCaretNext()
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

        private void DeleteBreakLineChar(ref string pText, string pChar = default)
        {
            pText = pChar == "1" || pChar == "I" ? string.Join(" ", Regex.Split(pText, mRegexRuleLineBreak)) : string.Join(string.Empty, Regex.Split(pText, mRegexRuleLineBreak));
        }

        /// <summary>
        /// Rajoute un espace si le charactere est '1' et supprime les caracteres de retour à la ligne
        /// </summary>
        /// <param name="pChar"></param>
        /// <returns></returns>
        private string FormatDisplayToStr(string pChar = default)
        {
            var lText = new TextRange(NumericDisplay.ContentStart, NumericDisplay.ContentEnd).Text;
            DeleteBreakLineChar(ref lText, pChar);

            return lText;
        }

        private void ComputeToDisplay(string pUserChar)
        {
            string lCurFormula = FormatDisplayToStr(pUserChar);

            //// Si on est au début de la saisie d'une formule
            //if (lCurFormula == "0")
            //{
            //    if (!CheckAuthorizedChars("0", pUserChar))
            //        return;
            //}
            //else // Dans les autres cas
            //{

            //}

            //if (lCurFormula.Length > 0)
            //{
            //    // Remplace le 1er caractere si '0' par un numérique si est digit ou parenthese ouvrante ou alphabetique
            //    if ((Char.IsDigit(pUserChar) || IsAuthorizedChars(mRegexOpenBracket + mRegexCloseBracket, pUserChar) || Char.IsLetter(pUserChar) || pUserChar == 'π' || pUserChar == '√') && lCurFormula == "0")
            //        lCurFormula = string.Empty;

            //    // Interdire le signe - s'il n'y a pas de nombre avant
            //    if (IsAuthorizedChars(mOperators, pUserChar) && lCurFormula == "0")
            //        return;

            //    // Test si dernier caractere différent de ['+','-','*','/']
            //    if (IsAuthorizedChars(mOperators, pUserChar) && IsAuthorizedChars(mOperators, lCurFormula.LastOrDefault()))
            //        return;

            //    // Empêche le point d'être saisi 2 fois sur le même nombre
            //    if (Regex.Split(lCurFormula, mRegexMathFunc).LastOrDefault().Contains(".") && pUserChar == '.')
            //        return;

            //    // Interdire la parenthèse ouvrante après un nombre
            //    if (Char.IsDigit(lCurFormula.LastOrDefault()) && pUserChar == '(')
            //        return;

            //    // Interdire la parenthèse ouvrante après un point
            //    if (lCurFormula.LastOrDefault() == '.' && pUserChar == '(')
            //        return;

            //    // Interdire la parenthese fermante si le dernier caractere est un opérateur
            //    if ((IsAuthorizedChars(mOperators, lCurFormula.LastOrDefault()) && pUserChar == ')'))
            //        return;

            //    // Interdire le point si le dernier caractere est une parenthèse fermante
            //    if (lCurFormula.LastOrDefault() == ')' && pUserChar == '.')
            //        return;

            //    // Interdire le point après les parentheses
            //    if ((lCurFormula.LastOrDefault() == '(') && (IsAuthorizedChars(mOperators, pUserChar)))
            //        return;

            //    // Interdire les caracteres alphanumerics
            //    if (IsAuthorizedChars(")", lCurFormula.LastOrDefault()) && !IsAuthorizedChars(mOperators, pUserChar) && pUserChar != '|')
            //        return;

            //    // Interdire la parenthèse fermante si pas de parenthese ouvrante avant, et fiabilise l'égalité du nombre de parenthèses ouvrantes et fermantes
            //    if (lCurFormula.Count(x => x == '(') == lCurFormula.Count(x => x == ')') && pUserChar == ')')
            //        return;

            //    // Interdire la parenthèse fermante si dernier caractere est parenthese ouvrante (parentheses vides)
            //    if (IsAuthorizedChars("(", lCurFormula.LastOrDefault()) && pUserChar == ')')
            //        return;

            //    // Interdire tout opérateurs après une parenthese ouvrante, sauf le signe '-'
            //    if (IsAuthorizedChars("(", lCurFormula.LastOrDefault()) && (pUserChar != '-' || !Char.IsDigit(pUserChar) || pUserChar != '√'))
            //        return;

            //    // Interdire la racine si racine déjà présente
            //    if (mRacine && pUserChar == '√')
            //        return;

            //    // Interdire le caractere de fermeture d'une racine s'il n'y a pas de racine active
            //    if (!mRacine && pUserChar == '|')
            //        return;

            //    // Interdire la saisie de la racine si le caractere précédent n'est pas un opérateur
            //    if (pUserChar == '√' && (!IsAuthorizedChars(mOperators, pUserChar) && lCurFormula.LastOrDefault() != '('))
            //        return;

            //    // Interdire la saisie autre qu'un digit ou une parenthèse ouvrante après le caractere racine
            //    if ((!Char.IsDigit(pUserChar) || pUserChar != '(') && lCurFormula.LastOrDefault() == '√')
            //        return;

            //}
            //else
            //{
            //    if (IsAuthorizedChars(mOperators, pUserChar))
            //        return;
            //}

            InsertNewCharToDisplay(pUserChar, lCurFormula);

            MoveCaretNext();

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

        private bool CheckAuthorizedChars(string pChar, char pUserChar)
        {
            // string lAuthorizedChars = GetLeft
            return true;
        }

        private void InsertNewCharToDisplay(string pUserChar, string pCurFormula)
        {
            NumericDisplay.Blocks.Clear();
            pCurFormula += pUserChar;
            NumericDisplay.Blocks.Add(ColorizeParagraph(pCurFormula));
        }

        public MainWindow()
        {
            InitializeComponent();

            // Récupère tous les symboles et fonctions de chaque touche et les chargent en mémoire
            GetAllSymbols();

            ComputeToDisplay("0");
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
                ComputeToDisplay("|");
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
                ComputeToDisplay("O");
            else
            {
                if (_Sept != string.Empty)
                    ComputeToDisplay(_Sept);
            }
        }

        private void Huit_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // Vn
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("P");
            else
                ComputeToDisplay("8");
        }

        private void Neuf_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // Wn
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("Q");
            else
                ComputeToDisplay("9");
        }

        private void Quatre_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L4
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("T");
            else
                ComputeToDisplay("4");
        }

        private void Cinq_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L5
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("U");
            else
                ComputeToDisplay("5");
        }

        private void Six_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L6
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("V");
            else
                ComputeToDisplay("6");
        }

        private void Un_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L1
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("Y");
            else
                ComputeToDisplay("1");
        }

        private void Deux_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L2
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("Z");
            else
                ComputeToDisplay("2");
        }

        private void Trois_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // L3
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("Θ");
            else
                ComputeToDisplay("3");
        }

        private void Zero_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // catalog
            }
            else if (alpha.FuncButtonIsChecked)
            {
                ComputeToDisplay(" ");
            }
            else
                ComputeToDisplay("0");
        }

        private void Point_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // i : information
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay(":");
            else
                ComputeToDisplay(".");
        }

        private void Enter_ToggleButtonClick(object sender, RoutedEventArgs e)
        {

            //FillEcranCalculGrapheContent(Calculate(), true);
        }

        private void Multiplier_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                ComputeToDisplay("[");
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("R");
            else
                ComputeToDisplay("×"); // #0215
        }

        private void Diviser_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                ComputeToDisplay("e");
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("M");
            else
                ComputeToDisplay("÷"); // #0247
        }

        private void Plus_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // mém
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("\"");
            else
                ComputeToDisplay("+"); // #043
        }

        private void Moins_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                ComputeToDisplay("]");
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("W");
            else
                ComputeToDisplay("-"); // #045
        }

        private void K_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                ComputeToDisplay("{");
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("K");
            else
                ComputeToDisplay("(");
        }

        private void L_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
                ComputeToDisplay("}");
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("L");
            else
                ComputeToDisplay(")");
        }

        private void H_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("H");
            else
                ComputeToDisplay("^");
        }

        private void I_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                ComputeToDisplay("√");
                mRacine = true;
            }
            else if (alpha.FuncButtonIsChecked)
                ComputeToDisplay("I");
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
                ComputeToDisplay("N");
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
                ComputeToDisplay("S");
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
                ComputeToDisplay("X");
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
                ComputeToDisplay("J");
            else
                ComputeToDisplay(",");
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
                ComputeToDisplay("˗"); // (-)
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
                ComputeToDisplay("A");
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
                ComputeToDisplay("B");
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
                ComputeToDisplay("C");
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

            string lText = FormatDisplayToStr();

            if (lText.Length > 0)
                lText = lText.Substring(0, lText.Length - 1);

            NumericDisplay.Blocks.Clear();
            NumericDisplay.Blocks.Add(ColorizeParagraph(lText));
            MoveCaretNext();
        }

        private void Angle_ToggleButtonClick(object sender, RoutedEventArgs e)
        {
            if (snde.FuncButtonIsChecked)
            {
                // angle
            }
            else if (alpha.FuncButtonIsChecked)
            {
                ComputeToDisplay("D");
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
                ComputeToDisplay("π");
            }
            else if (alpha.FuncButtonIsChecked)
            {
                ComputeToDisplay("E");
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
                ComputeToDisplay("F");
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
                ComputeToDisplay("G");
            }
            else
            {
                // ▀∕▄
            }
        }
    }
}
