using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Media;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int a = 0;
        bool keye = false;
        bool keyq = false;
        bool keyw = false;
        bool keya = false;
        bool keyb = false;
        bool keyc = false;
        bool keyf = false;
        bool keyg = false;
        bool keyh = false;
        bool keyi = false;
        bool keyj = false;
        bool keyk = false;
        bool keyl = false;
        bool keym = false;
        bool keyn = false;
        bool keyo = false;
        bool keyp = false;
        bool keyr = false;
        bool keyt = false;
        bool keyu = false;
        bool keyv = false;
        bool keyx = false;
        bool keyy = false;
        bool keyz = false;
        bool keys = false;
        bool keyd = false;
        bool key1 = false;
        bool key2 = false;
        bool key3 = false;
        bool key4 = false;
        bool key5 = false;
        bool key6 = false;
        bool key7 = false;
        bool key8 = false;
        bool key9 = false;
        bool key0 = false;
        bool keycom = false;
        bool keyper = false;
        bool keyque = false;
        bool keysem = false;
        bool keyobb = false;
        bool keyclb = false;
        bool keyquo = false;
        bool keymin = false;
        bool keypls = false;
        bool keypip = false;
        bool keytid = false;
        bool keytab = false;
        bool keycap = false;
        bool keylsh = false;
        bool keyrsh = false;
        bool keylct = false;
        bool keyrct = false;
        bool keylwn = false;
        bool keylat = false;
        bool keysps = false;
        bool keyrwn = false;
        bool keyrat = false;
        bool keybac = false;
        bool keyent = false;
        bool keyapp = false;
        bool keyesc = false;
        bool keyf1 = false;
        bool keyf2 = false;
        bool keyf3 = false;
        bool keyf4 = false;
        bool keyf5 = false;
        bool keyf6 = false;
        bool keyf7 = false;
        bool keyf8 = false;
        bool keyf9 = false;
        bool keyf10 = false;
        bool keyf11 = false;
        bool keyf12 = false;
        bool keyshot = false;
        bool keyscr = false;
        bool keypbr = false;
        bool keyins = false;
        bool keyhom = false;
        bool keypgu = false;
        bool keydel = false;
        bool keyend = false;
        bool keypgd = false;
        bool keyup = false;
        bool keydown = false;
        bool keyleft = false;
        bool keyright = false;
        bool keydiv = false;
        bool keymul = false;
        bool keysub = false;
        bool keysum = false;
        bool keynum = false;
        bool key1num = false;
        bool key2num = false;
        bool key3num = false;
        bool key4num = false;
        bool key5num = false;
        bool key6num = false;
        bool key7num = false;
        bool key8num = false;
        bool key9num = false;
        bool key0num = false;
        bool keydec = false;
        bool keynument = false;
        int altpressed = 0;
        bool mboxwindow = false;

        SoundPlayer click_sound = new SoundPlayer(Application.StartupPath + "/Sound/Click.wav");

        //--------------------------
        // needed for right/left alt
        //--------------------------
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys Key);

        //---------------------------------
        // needed for right/left shift/ctrl
        //---------------------------------
        protected override bool ProcessKeyMessage(ref Message m)
        {
            if ((m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP) && ((int)m.WParam == VK_CONTROL || (int)m.WParam == VK_SHIFT))
            {
                KeyEventArgs e = new KeyEventArgs(Keys.None);
                switch ((OemScanCode)(((int)m.LParam >> 16) & 0x1FF))
                {
                    case OemScanCode.LControl:
                        e = new KeyEventArgs(Keys.LControlKey);
                        break;
                    case OemScanCode.RControl:
                        e = new KeyEventArgs(Keys.RControlKey);
                        break;
                    case OemScanCode.RShift:
                        e = new KeyEventArgs(Keys.RShiftKey);
                        break;
                    case OemScanCode.LShift:
                        e = new KeyEventArgs(Keys.LShiftKey);
                        break;
                    default:
                        if ((int)m.WParam == VK_SHIFT)
                            e = new KeyEventArgs(Keys.ShiftKey);
                        else if ((int)m.WParam == VK_CONTROL)
                            e = new KeyEventArgs(Keys.ControlKey);
                        break;
                }
                if (e.KeyData != Keys.None)
                {
                    if (m.Msg == WM_KEYDOWN)
                        OnKeyDown(e);
                    else
                        OnKeyUp(e);
                    return true;
                }
            }
            return base.ProcessKeyMessage(ref m);
        }
        #region Scan code & window message stuff
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;

        const int VK_SHIFT = 0x10;
        const int VK_CONTROL = 0x11;
        /// <summary>
        /// Alt key
        /// </summary>
        const int VK_MENU = 0x12;

        /// <summary>
        /// List of scan codes for standard 104-key keyboard US English keyboard
        /// </summary>
        enum OemScanCode
        {
            /// <summary>
            /// ` ~
            /// </summary>
            BacktickTilde = 0x29,
            /// <summary>
            /// 1 !
            /// </summary>
            N1 = 2,
            /// <summary>
            /// 2 @
            /// </summary>
            N2 = 3,
            /// <summary>
            /// 3 #
            /// </summary>
            N3 = 4,
            /// <summary>
            /// 4 $
            /// </summary>
            N4 = 5,
            /// <summary>
            /// 5 %
            /// </summary>
            N5 = 6,
            /// <summary>
            /// 6 ^
            /// </summary>
            N6 = 7,
            /// <summary>
            /// 7 &
            /// </summary>
            N7 = 8,
            /// <summary>
            /// 8 *
            /// </summary>
            N8 = 9,
            /// <summary>
            /// 9 (
            /// </summary>
            N9 = 0x0A,
            /// <summary>
            /// 0 )
            /// </summary>
            N0 = 0x0B,
            /// <summary>
            /// - _
            /// </summary>
            MinusDash = 0x0C,
            /// <summary>
            /// = +
            /// </summary>
            Equals = 0x0D,
            Backspace = 0x0E,
            Tab = 0x0F,
            Q = 0x10,
            W = 0x11,
            E = 0x12,
            R = 0x13,
            T = 0x14,
            Y = 0x15,
            U = 0x16,
            I = 0x17,
            O = 0x18,
            P = 0x19,
            /// <summary>
            /// [ {
            /// </summary>
            LBracket = 0x1A,
            /// <summary>
            /// ] }
            /// </summary>
            RBracket = 0x1B,
            /// <summary>
            /// | \ (same as pipe)
            /// </summary>
            VerticalBar = 0x2B,
            /// <summary>
            /// | \ (same as vertical bar)
            /// </summary>
            Pipe = 0x2B,
            CapsLock = 0x3A,
            A = 0x1E,
            S = 0x1F,
            D = 0x20,
            F = 0x21,
            G = 0x22,
            H = 0x23,
            J = 0x24,
            K = 0x25,
            L = 0x26,
            /// <summary>
            /// ; :
            /// </summary>
            SemiColon = 0x27,
            /// <summary>
            /// ' "
            /// </summary>
            Quotes = 0x28,
            // Unused
            Enter = 0x1C,
            LShift = 0x2A,
            Z = 0x2C,
            X = 0x2D,
            C = 0x2E,
            V = 0x2F,
            B = 0x30,
            N = 0x31,
            M = 0x32,
            /// <summary>
            /// , <
            /// </summary>
            Comma = 0x33,
            /// <summary>
            /// . >
            /// </summary>
            Period = 0x34,
            /// <summary>
            /// / ?
            /// </summary>
            Slash = 0x35,
            RShift = 0x36,
            LControl = 0x1D,
            LMenuq = 0xA4,
            SpaceBar = 0x39,
            RMenuq = 0xA5,
            RControl = 0x11D,
            /// <summary>
            /// The menu key thingy
            /// </summary>
            Application = 0x15D,
            Insert = 0x152,
            Delete = 0x153,
            Home = 0x147,
            End = 0x14F,
            PageUp = 0x149,
            PageDown = 0x151,
            UpArrow = 0x148,
            DownArrow = 0x150,
            LeftArrow = 0x14B,
            RightArrow = 0x14D,
            NumLock = 0x145,
            NumPad0 = 0x52,
            NumPad1 = 0x4F,
            NumPad2 = 0x50,
            NumPad3 = 0x51,
            NumPad4 = 0x4B,
            NumPad5 = 0x4C,
            NumPad6 = 0x4D,
            NumPad7 = 0x47,
            NumPad8 = 0x48,
            NumPad9 = 0x49,
            NumPadDecimal = 0x53,
            NumPadEnter = 0x11C,
            NumPadPlus = 0x4E,
            NumPadMinus = 0x4A,
            NumPadAsterisk = 0x37,
            NumPadSlash = 0x135,
            Escape = 1,
            PrintScreen = 0x137,
            ScrollLock = 0x46,
            PauseBreak = 0x45,
            LeftWindows = 0x15B,
            RightWindows = 0x15C,
            F1 = 0x3B,
            F2 = 0x3C,
            F3 = 0x3D,
            F4 = 0x3E,
            F5 = 0x3F,
            F6 = 0x40,
            F7 = 0x41,
            F8 = 0x42,
            F9 = 0x43,
            F10 = 0x44,
            F11 = 0x57,
            F12 = 0x58,
        }
        #endregion

        //------------------------
        // you can't use Alt+F4 !!
        //------------------------
        public class AltF4Filter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                const int WM_SYSKEYDOWN = 0x0104;
                if (m.Msg == WM_SYSKEYDOWN)
                {
                    bool alt = ((int)m.LParam & 0x20000000) != 0;
                    if (alt && (m.WParam == new IntPtr((int)Keys.F4)))
                        return true;
                }
                return false;
            }
        }

        //----------------------------------------------------
        // difference between normal enter and numpad enter !!
        //----------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 256 && m.WParam.ToInt32() == 13)
            {
                if ((m.LParam.ToInt32() >> 24) == 0)
                {
                    if (keyent == false)
                    {
                        keyent = true;
                        pictureBox58.BackColor = Color.Red;
                        pictureBox59.BackColor = Color.Red;
                        inputbutton();
                    }
                }
                else
                {
                    if (keynument == false)
                    {
                        keynument = true;
                        pictureBox98.BackColor = Color.Red;
                        inputbutton();
                    }
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }


        private void inputbutton()
        {
            a++;
            click_sound.Play();
        }
        private void outputbutton()
        {
            a--;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++ keydown ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Sending Ctrl to prevent startmenu to shows up (strange huh ?)
            if (e.KeyCode == Keys.LWin)
            {
                SendKeys.Send("^");
            }
            if (e.KeyCode == Keys.RWin)
            {
                SendKeys.Send("^");
            }

            e.SuppressKeyPress = true;
            #region qwertykeys
            if (e.KeyCode == Keys.W)
            {
                if (keyw == false)
                {
                    keyw = true;
                    pictureBox1.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                if (keyq == false)
                {
                    keyq = true;
                    pictureBox5.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.E)
            {
                if (keye == false)
                {
                    keye = true;
                    pictureBox6.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.A)
            {
                if (keya == false)
                {
                    keya = true;
                    pictureBox2.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.S)
            {
                if (keys == false)
                {
                    keys = true;
                    pictureBox3.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.D)
            {
                if (keyd == false)
                {
                    keyd = true;
                    pictureBox4.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                if (keyz == false)
                {
                    keyz = true;
                    pictureBox7.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.X)
            {
                if (keyx == false)
                {
                    keyx = true;
                    pictureBox8.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.C)
            {
                if (keyc == false)
                {
                    keyc = true;
                    pictureBox9.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.R)
            {
                if (keyr == false)
                {
                    keyr = true;
                    pictureBox10.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.F)
            {
                if (keyf == false)
                {
                    keyf = true;
                    pictureBox11.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.V)
            {
                if (keyv == false)
                {
                    keyv = true;
                    pictureBox12.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.T)
            {
                if (keyt == false)
                {
                    keyt = true;
                    pictureBox13.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.G)
            {
                if (keyg == false)
                {
                    keyg = true;
                    pictureBox14.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.B)
            {
                if (keyb == false)
                {
                    keyb = true;
                    pictureBox15.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.Y)
            {
                if (keyy == false)
                {
                    keyy = true;
                    pictureBox16.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.H)
            {
                if (keyh == false)
                {
                    keyh = true;
                    pictureBox17.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.N)
            {
                if (keyn == false)
                {
                    keyn = true;
                    pictureBox18.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.U)
            {
                if (keyu == false)
                {
                    keyu = true;
                    pictureBox19.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.J)
            {
                if (keyj == false)
                {
                    keyj = true;
                    pictureBox20.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.M)
            {
                if (keym == false)
                {
                    keym = true;
                    pictureBox21.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.I)
            {
                if (keyi == false)
                {
                    keyi = true;
                    pictureBox22.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.K)
            {
                if (keyk == false)
                {
                    keyk = true;
                    pictureBox23.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.Oemcomma)
            {
                if (keycom == false)
                {
                    keycom = true;
                    pictureBox24.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.O)
            {
                if (keyo == false)
                {
                    keyo = true;
                    pictureBox25.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.L)
            {
                if (keyl == false)
                {
                    keyl = true;
                    pictureBox26.BackColor = Color.Red;
                    inputbutton();
                }
            }
            if (e.KeyCode == Keys.OemPeriod && keyper == false)
            {
                keyper = true;
                pictureBox27.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.P && keyp == false)
            {
                keyp = true;
                pictureBox28.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemSemicolon && keysem == false)
            {
                keysem = true;
                pictureBox29.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemQuestion && keyque == false)
            {
                keyque = true;
                pictureBox30.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemOpenBrackets && keyobb == false)
            {
                keyobb = true;
                pictureBox31.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemQuotes && keyquo == false)
            {
                keyquo = true;
                pictureBox32.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemCloseBrackets && keyclb == false)
            {
                keyclb = true;
                pictureBox33.BackColor = Color.Red;
                inputbutton();
            }
            #endregion
            if (e.KeyCode == Keys.D1 && key1 == false)
            {
                key1 = true;
                pictureBox34.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D2 && key2 == false)
            {
                key2 = true;
                pictureBox35.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D3 && key3 == false)
            {
                key3 = true;
                pictureBox36.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D4 && key4 == false)
            {
                key4 = true;
                pictureBox37.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D5 && key5 == false)
            {
                key5 = true;
                pictureBox38.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D6 && key6 == false)
            {
                key6 = true;
                pictureBox39.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D7 && key7 == false)
            {
                key7 = true;
                pictureBox40.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D8 && key8 == false)
            {
                key8 = true;
                pictureBox41.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D9 && key9 == false)
            {
                key9 = true;
                pictureBox42.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.D0 && key0 == false)
            {
                key0 = true;
                pictureBox43.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemMinus && keymin == false)
            {
                keymin = true;
                pictureBox44.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Oemplus && keypls == false)
            {
                keypls = true;
                pictureBox45.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.OemPipe && keypip == false)
            {
                keypip = true;
                pictureBox46.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Oemtilde && keytid == false)
            {
                keytid = true;
                pictureBox47.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Tab && keytab == false)
            {
                keytab = true;
                pictureBox48.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.CapsLock && keycap == false)
            {
                keycap = true;
                pictureBox49.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.LControlKey && keylct == false)
            {
                keylct = true;
                pictureBox51.BackColor = Color.Red;
                inputbutton();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.LWin && keylwn == false)
            {
                keylwn = true;
                pictureBox52.BackColor = Color.Red;
                inputbutton();
                e.Handled = true;
                Focus();
                e.SuppressKeyPress = true;
            }

            if (e.Alt && keylat == false)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
                {
                    altpressed++;
                    keylat = true;
                    pictureBox53.BackColor = Color.Red;
                    inputbutton();
                    Focus();
                    e.SuppressKeyPress = true;
                }
            }
            if (e.Alt && keyrat == false)
            {
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
                {
                    altpressed++;
                    keyrat = true;
                    pictureBox55.BackColor = Color.Red;
                    inputbutton();
                    Focus();
                    e.SuppressKeyPress = true;
                }
            }
            if (e.KeyCode == Keys.Space && keysps == false)
            {
                keysps = true;
                pictureBox54.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.RWin && keyrwn == false)
            {
                keyrwn = true;
                pictureBox56.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Back && keybac == false)
            {
                keybac = true;
                pictureBox57.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.RShiftKey && keyrsh == false)
            {
                keyrsh = true;
                pictureBox60.BackColor = Color.Red;
                inputbutton();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.LShiftKey && keylsh == false)
            {
                keylsh = true;
                pictureBox50.BackColor = Color.Red;
                inputbutton();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.RControlKey && keyrct == false)
            {
                keyrct = true;
                pictureBox61.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Apps && keyapp == false)
            {
                keyapp = true;
                pictureBox62.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Escape && keyesc == false)
            {
                keyesc = true;
                pictureBox63.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F1 && keyf1 == false)
            {
                keyf1 = true;
                pictureBox64.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F2 && keyf2 == false)
            {
                keyf2 = true;
                pictureBox65.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F3 && keyf3 == false)
            {
                keyf3 = true;
                pictureBox66.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F4 && keyf4 == false)
            {
                keyf4 = true;
                pictureBox67.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F5 && keyf5 == false)
            {
                keyf5 = true;
                pictureBox68.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F6 && keyf6 == false)
            {
                keyf6 = true;
                pictureBox69.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F7 && keyf7 == false)
            {
                keyf7 = true;
                pictureBox70.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F8 && keyf8 == false)
            {
                keyf8 = true;
                pictureBox71.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F9 && keyf9 == false)
            {
                keyf9 = true;
                pictureBox72.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F10 && keyf10 == false)
            {
                keyf10 = true;
                pictureBox73.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F11 && keyf11 == false)
            {
                keyf11 = true;
                pictureBox74.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.F12 && keyf12 == false)
            {
                keyf12 = true;
                pictureBox75.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Snapshot && keyshot == false)
            {
                keyshot = true;
                pictureBox76.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Scroll && keyscr == false)
            {
                keyscr = true;
                pictureBox77.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Pause && keypbr == false)
            {
                keypbr = true;
                pictureBox78.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Insert && keyins == false)
            {
                keyins = true;
                pictureBox79.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Home && keyhom == false)
            {
                keyhom = true;
                pictureBox80.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.PageUp && keypgu == false)
            {
                keypgu = true;
                pictureBox81.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Delete && keydel == false)
            {
                keydel = true;
                pictureBox82.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.End && keyend == false)
            {
                keyend = true;
                pictureBox83.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.PageDown && keypgd == false)
            {
                keypgd = true;
                pictureBox84.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Left && keyleft == false)
            {
                keyleft = true;
                pictureBox85.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Down && keydown == false)
            {
                keydown = true;
                pictureBox86.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Right && keyright == false)
            {
                keyright = true;
                pictureBox87.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Up && keyup == false)
            {
                keyup = true;
                pictureBox88.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumLock && keynum == false)
            {
                keynum = true;
                pictureBox89.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Divide && keydiv == false)
            {
                keydiv = true;
                pictureBox90.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Multiply && keymul == false)
            {
                keymul = true;
                pictureBox91.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Subtract && keysub == false)
            {
                keysub = true;
                pictureBox92.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad7 && key7num == false)
            {
                key7num = true;
                pictureBox93.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad4 && key4num == false)
            {
                key4num = true;
                pictureBox94.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad1 && key1num == false)
            {
                key1num = true;
                pictureBox95.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad0 && key0num == false)
            {
                key0num = true;
                pictureBox96.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Decimal && keydec == false)
            {
                keydec = true;
                pictureBox97.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.Add && keysum == false)
            {
                keysum = true;
                pictureBox99.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad8 && key8num == false)
            {
                key8num = true;
                pictureBox100.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad9 && key9num == false)
            {
                key9num = true;
                pictureBox101.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad5 && key5num == false)
            {
                key5num = true;
                pictureBox102.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad6 && key6num == false)
            {
                key6num = true;
                pictureBox103.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad2 && key2num == false)
            {
                key2num = true;
                pictureBox104.BackColor = Color.Red;
                inputbutton();
            }
            if (e.KeyCode == Keys.NumPad3 && key3num == false)
            {
                key3num = true;
                pictureBox105.BackColor = Color.Red;
                inputbutton();
            }

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //++++++++++++++++++++++ key up +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                pictureBox1.BackColor = Color.DimGray;
                keyw = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.A)
            {
                pictureBox2.BackColor = Color.DimGray;
                keya = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.S)
            {
                pictureBox3.BackColor = Color.DimGray;
                keys = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D)
            {
                pictureBox4.BackColor = Color.DimGray;
                keyd = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Q)
            {
                pictureBox5.BackColor = Color.DimGray;
                keyq = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.E)
            {
                pictureBox6.BackColor = Color.DimGray;
                keye = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Z)
            {
                pictureBox7.BackColor = Color.DimGray;
                keyz = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.X)
            {
                pictureBox8.BackColor = Color.DimGray;
                keyx = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.C)
            {
                pictureBox9.BackColor = Color.DimGray;
                keyc = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.R)
            {
                pictureBox10.BackColor = Color.DimGray;
                keyr = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F)
            {
                pictureBox11.BackColor = Color.DimGray;
                keyf = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.V)
            {
                pictureBox12.BackColor = Color.DimGray;
                keyv = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.T)
            {
                pictureBox13.BackColor = Color.DimGray;
                keyt = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.G)
            {
                pictureBox14.BackColor = Color.DimGray;
                keyg = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.B)
            {
                pictureBox15.BackColor = Color.DimGray;
                keyb = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Y)
            {
                pictureBox16.BackColor = Color.DimGray;
                keyy = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.H)
            {
                pictureBox17.BackColor = Color.DimGray;
                keyh = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.N)
            {
                pictureBox18.BackColor = Color.DimGray;
                keyn = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.U)
            {
                pictureBox19.BackColor = Color.DimGray;
                keyu = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.J)
            {
                pictureBox20.BackColor = Color.DimGray;
                keyj = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.M)
            {
                pictureBox21.BackColor = Color.DimGray;
                keym = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.I)
            {
                pictureBox22.BackColor = Color.DimGray;
                keyi = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.K)
            {
                pictureBox23.BackColor = Color.DimGray;
                keyk = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Oemcomma)
            {
                pictureBox24.BackColor = Color.DimGray;
                keycom = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.O)
            {
                pictureBox25.BackColor = Color.DimGray;
                keyo = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.L)
            {
                pictureBox26.BackColor = Color.DimGray;
                keyl = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemPeriod)
            {
                pictureBox27.BackColor = Color.DimGray;
                keyper = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.P)
            {
                pictureBox28.BackColor = Color.DimGray;
                keyp = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemSemicolon)
            {
                pictureBox29.BackColor = Color.DimGray;
                keysem = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                pictureBox30.BackColor = Color.DimGray;
                keyque = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                pictureBox31.BackColor = Color.DimGray;
                keyobb = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemQuotes)
            {
                pictureBox32.BackColor = Color.DimGray;
                keyquo = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemCloseBrackets)
            {
                pictureBox33.BackColor = Color.DimGray;
                keyclb = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D1)
            {
                pictureBox34.BackColor = Color.DimGray;
                key1 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D2)
            {
                pictureBox35.BackColor = Color.DimGray;
                key2 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D3)
            {
                pictureBox36.BackColor = Color.DimGray;
                key3 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D4)
            {
                pictureBox37.BackColor = Color.DimGray;
                key4 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D5)
            {
                pictureBox38.BackColor = Color.DimGray;
                key5 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D6)
            {
                pictureBox39.BackColor = Color.DimGray;
                key6 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D7)
            {
                pictureBox40.BackColor = Color.DimGray;
                key7 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D8)
            {
                pictureBox41.BackColor = Color.DimGray;
                key8 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D9)
            {
                pictureBox42.BackColor = Color.DimGray;
                key9 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.D0)
            {
                pictureBox43.BackColor = Color.DimGray;
                key0 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                pictureBox44.BackColor = Color.DimGray;
                keymin = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Oemplus)
            {
                pictureBox45.BackColor = Color.DimGray;
                keypls = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.OemPipe)
            {
                pictureBox46.BackColor = Color.DimGray;
                keypip = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Oemtilde)
            {
                pictureBox47.BackColor = Color.DimGray;
                keytid = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Tab)
            {
                pictureBox48.BackColor = Color.DimGray;
                keytab = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.CapsLock)
            {
                pictureBox49.BackColor = Color.DimGray;
                keycap = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.LWin)
            {
                pictureBox52.BackColor = Color.DimGray;
                keylwn = false;
                outputbutton();
                e.Handled = true;
                Focus();
            }
            if (e.KeyCode == Keys.Space)
            {
                pictureBox54.BackColor = Color.DimGray;
                keysps = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.RWin)
            {
                pictureBox56.BackColor = Color.DimGray;
                keyrwn = false;
                outputbutton();
                e.Handled = true;
                Focus();
            }
            if (e.KeyCode == Keys.Back)
            {
                pictureBox57.BackColor = Color.DimGray;
                keybac = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox58.BackColor = Color.DimGray;
                pictureBox59.BackColor = Color.DimGray;
                keyent = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Apps)
            {
                pictureBox62.BackColor = Color.DimGray;
                keyapp = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox63.BackColor = Color.DimGray;
                keyesc = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F1)
            {
                pictureBox64.BackColor = Color.DimGray;
                keyf1 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F2)
            {
                pictureBox65.BackColor = Color.DimGray;
                keyf2 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F3)
            {
                pictureBox66.BackColor = Color.DimGray;
                keyf3 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F4)
            {
                pictureBox67.BackColor = Color.DimGray;
                keyf4 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F5)
            {
                pictureBox68.BackColor = Color.DimGray;
                keyf5 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F6)
            {
                pictureBox69.BackColor = Color.DimGray;
                keyf6 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F7)
            {
                pictureBox70.BackColor = Color.DimGray;
                keyf7 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F8)
            {
                pictureBox71.BackColor = Color.DimGray;
                keyf8 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F9)
            {
                pictureBox72.BackColor = Color.DimGray;
                keyf9 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F10)
            {
                pictureBox73.BackColor = Color.DimGray;
                keyf10 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F11)
            {
                pictureBox74.BackColor = Color.DimGray;
                keyf11 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.F12)
            {
                pictureBox75.BackColor = Color.DimGray;
                keyf12 = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Snapshot)
            {
                pictureBox76.BackColor = Color.DimGray;
                keyshot = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Scroll)
            {
                pictureBox77.BackColor = Color.DimGray;
                keyscr = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Pause)
            {
                pictureBox78.BackColor = Color.DimGray;
                keypbr = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Insert)
            {
                pictureBox79.BackColor = Color.DimGray;
                keyins = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Home)
            {
                pictureBox80.BackColor = Color.DimGray;
                keyhom = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.PageUp)
            {
                pictureBox81.BackColor = Color.DimGray;
                keypgu = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Delete)
            {
                pictureBox82.BackColor = Color.DimGray;
                keydel = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.End)
            {
                pictureBox83.BackColor = Color.DimGray;
                keyend = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.PageDown)
            {
                pictureBox84.BackColor = Color.DimGray;
                keypgd = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Left)
            {
                pictureBox85.BackColor = Color.DimGray;
                keyleft = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Down)
            {
                pictureBox86.BackColor = Color.DimGray;
                keydown = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Right)
            {
                pictureBox87.BackColor = Color.DimGray;
                keyright = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Up)
            {
                pictureBox88.BackColor = Color.DimGray;
                keyup = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumLock)
            {
                pictureBox89.BackColor = Color.DimGray;
                keynum = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Divide)
            {
                pictureBox90.BackColor = Color.DimGray;
                keydiv = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                pictureBox91.BackColor = Color.DimGray;
                keymul = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                pictureBox92.BackColor = Color.DimGray;
                keysub = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                pictureBox93.BackColor = Color.DimGray;
                key7num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                pictureBox94.BackColor = Color.DimGray;
                key4num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad1)
            {
                pictureBox95.BackColor = Color.DimGray;
                key1num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad0)
            {
                pictureBox96.BackColor = Color.DimGray;
                key0num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Decimal)
            {
                pictureBox97.BackColor = Color.DimGray;
                keydec = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.Return)
            {
                pictureBox98.BackColor = Color.DimGray;
                keynument = false;
            }
            if (e.KeyCode == Keys.Add)
            {
                pictureBox99.BackColor = Color.DimGray;
                keysum = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                pictureBox100.BackColor = Color.DimGray;
                key8num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad9)
            {
                pictureBox101.BackColor = Color.DimGray;
                key9num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad5)
            {
                pictureBox102.BackColor = Color.DimGray;
                key5num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                pictureBox103.BackColor = Color.DimGray;
                key6num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                pictureBox104.BackColor = Color.DimGray;
                key2num = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.NumPad3)
            {
                pictureBox105.BackColor = Color.DimGray;
                key3num = false;
                outputbutton();
            }
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            #region Ctrl Shift and Alt button test **********************************
            if (e.KeyCode == Keys.Menu)
            {
                e.Handled = true;
                if (altpressed != 2)
                {
                    if (keylat == true)
                    {
                        e.SuppressKeyPress = true;
                        pictureBox53.BackColor = Color.DimGray;
                        keylat = false;
                        outputbutton();
                        Focus();
                        e.Handled = true;
                    }
                    if (keyrat == true)
                    {
                        e.SuppressKeyPress = true;
                        pictureBox55.BackColor = Color.DimGray;
                        keyrat = false;
                        outputbutton();
                        Focus();
                        e.Handled = true;
                    }
                    altpressed--;
                }
                else if (altpressed == 2)
                {
                    if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
                    {
                        e.SuppressKeyPress = true;
                        pictureBox55.BackColor = Color.DimGray;
                        keyrat = false;
                        Focus();
                        e.Handled = true;
                        outputbutton();
                    }
                    else if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
                    {
                        e.SuppressKeyPress = true;
                        pictureBox53.BackColor = Color.DimGray;
                        keylat = false;
                        Focus();
                        e.Handled = true;
                        outputbutton();
                    }
                    altpressed--;
                }
            }

            e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.RShiftKey)
            {
                pictureBox60.BackColor = Color.DimGray;
                keyrsh = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.LShiftKey)
            {
                pictureBox50.BackColor = Color.DimGray;
                keylsh = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.RControlKey)
            {
                pictureBox61.BackColor = Color.DimGray;
                keyrct = false;
                outputbutton();
            }
            if (e.KeyCode == Keys.LControlKey)
            {
                pictureBox51.BackColor = Color.DimGray;
                keylct = false;
                outputbutton();
            }

            #endregion 
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Focus();
        } 

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // without this, first start button will shows up startmenu if you press windows button very fast
            SendKeys.Send("^");
        }
    }
}
