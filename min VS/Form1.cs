using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace min_VS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] lines;
        class variable
        {
            public string datatype;
            public string name;
        }
        class intvariable : variable
        {
            public int value;
        }
        class floatvariable : variable
        {
            public float value;
        }
        class stringvariable : variable
        {
            public string value;
        }
        class doublevariable : variable
        {
            public double value;
        }
        class boolvariable : variable
        {
            public bool value;
        }
        class charvariable : variable
        {
            public char value;
        }
        public string code;
        List<intvariable> allint = new List<intvariable>();
        List<floatvariable> allfloat = new List<floatvariable>();
        List<doublevariable> alldouble = new List<doublevariable>();
        List<boolvariable> allbool = new List<boolvariable>();
        List<charvariable> allchar = new List<charvariable>();
        List<variable> allvariables = new List<variable>();
        bool error = false;
        List<string> infix = new List<string>();
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            //memory
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            //screen
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allint.Clear();
            allvariables.Clear();
            richTextBox2.Text = "";
            code = richTextBox1.Text;
            lines = code.Split('\n').ToArray();



            comp();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int i, k, f1 = 0, f2 = 0, f3 = 0, f4 = 0;
        void comp()
        {
            for (i = 0; i < lines.Count(); i++)
            {

                f1 = 0;


                //if (lines[i][k] == ' '|| lines[i].Count() >1)
                //{
                //    MessageBox.Show(k + "");
                //    continue;
                //}
                floatIdentifiers(i, 0);
                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }
                boolIdentifiers(i, 0);
                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }
                forcon();
                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }
                ifcon();
                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }

                intIdentifiers(i, 0);

                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }

                floatIdentifiers(i, 0);
                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }




                intIdentifiers2(i, 0);

                if (error)
                {
                    break;
                }
                if (f1 == 1)
                {
                    continue;
                }
                if (error)
                {
                    break;
                }




            }
        }
        int getintresalt(int k2, int i2)

        {
            string var = "";
            string var2 = "";
            int varint1 = 0;
            int varint2 = 0;

            char op = ' ';

            for (int i5 = 0; i5 < 2; i5++)
            {
                var = "";
                var2 = "";
                //remove space
                for (; i2 < lines.Count() && k2 < lines[i2].Count() && lines[i2][k2] == ' '; k2++)
                {
                }
                if (i2 >= lines.Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                    return 0;
                }
                if (k2 >= lines[i2].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                    return 0;
                }
                //check if number
                if ((lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                {
                    for (; k2 < lines[i2].Count() && lines[i2][k2] != ' ' && lines[i2][k2] != ';'; k2++)
                    {
                        if ((lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                        {

                            var += lines[i2][k2];
                        }
                        else
                        {
                            MessageBox.Show("error");
                            error = true;
                            return 0;
                        }
                    }
                    bool isParsable;
                    if (i5 == 0)
                    {
                        isParsable = Int32.TryParse(var, out varint1);
                    }
                    else
                    {
                        isParsable = Int32.TryParse(var, out varint2);

                    }
                    if (isParsable)
                    {
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("error");
                        return 0;
                    }

                    if (k2 > lines[i2].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        return 0;
                    }

                    //remove space
                    for (; lines[i2][k2] == ' '; k2++)
                    {
                    }

                    if (k2 > lines[i2].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        return 0;
                    }
                    if (lines[i2][k2] == ';' || lines[i2][k2] == ')' || lines[i2][k2] == '>' || lines[i2][k2] == '<' || lines[i2][k2] == '=' || lines[i2][k2] == '&'
                        || lines[i2][k2] == '|')
                    {
                        if (i5 == 0)
                        {
                            return varint1;
                        }
                        if (op == '+')
                            return varint1 + varint2;
                        if (op == '-')
                            return varint1 - varint2;
                        if (op == '*')
                            return varint1 * varint2;
                        if (op == '/')
                            return varint1 / varint2;
                    }
                    if (lines[i2][k2] == '+' || lines[i2][k2] == '-' || lines[i2][k2] == '*' || lines[i2][k2] == '/')
                    {
                        op = lines[i2][k2];
                        k2++;
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "");
                        return 0;
                    }
                    if (k2 > lines[i2].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        return 0;
                    }


                }
                else
                {
                    for (; k2 < lines[i2].Count() && lines[i2][k2] != ' ' && lines[i2][k2] != ';'; k2++)
                    {
                        if ((lines[i2][k2] >= 'a' && lines[i2][k2] <= 'z') ||
                            (lines[i2][k2] >= 'A' && lines[i2][k2] <= 'Z') ||
                            (lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                        {
                            var2 += lines[i2][k2];
                        }
                        else
                        {
                            MessageBox.Show("Error in line " + i2 + 1 + " You Cant use" + lines[i2][k2] + " in variable name");
                            error = true;
                            return 0;
                            break;

                        }
                    }

                    //check if name is exist before
                    int flag = 1;
                    for (int m = 0; m < allvariables.Count(); m++)
                    {
                        if (var2 == allint[m].name)
                        {
                            if (i5 == 0)
                            {
                                varint1 = allint[m].value;


                            }
                            else
                            {
                                varint2 = allint[m].value;
                            }
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        if (k2 > lines[i2].Count())
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                            return 0;
                        }

                        //remove space
                        for (; k2 < lines[i2].Count() && lines[i2][k2] == ' '; k2++)
                        {
                        }

                        if (k2 >= lines[i2].Count())
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + "the line not copmlet");
                            return 0;
                        }
                        if (lines[i2][k2] == ';' || lines[i2][k2] == ')' || lines[i2][k2] == '>' || lines[i2][k2] == '<' || lines[i2][k2] == '=' || lines[i2][k2] == '&'
                        || lines[i2][k2] == '|')
                        {
                            if (i5 == 0)
                            {
                                return varint1;
                            }
                            if (op == '+')
                                return varint1 + varint2;
                            if (op == '-')
                                return varint1 - varint2;
                            if (op == '*')
                                return varint1 * varint2;
                            if (op == '/')
                                return varint1 / varint2;
                        }
                        if (lines[i2][k2] == '+' || lines[i2][k2] == '-' || lines[i2][k2] == '*' || lines[i2][k2] == '/')
                        {
                            op = lines[i2][k2];
                            k2++;
                        }
                        else
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + 1 + "");
                            return 0;
                        }
                        if (k2 > lines[i2].Count())
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        }
                    }
                    else
                    {
                        error = true;

                        MessageBox.Show("error in line  " + i2 + 1 + "the varible not found");
                        return 0;

                    }
                }

            }
            return 0;
        }
        float getfloatresalt(int k2, int i2)

        {
            string var = "";
            string var2 = "";
            float varint1 = 0;
            float varint2 = 0;

            char op = ' ';

            for (int i5 = 0; i5 < 2; i5++)
            {
                var = "";
                var2 = "";
                //remove space
                for (; i2 < lines.Count() && k2 < lines[i2].Count() && lines[i2][k2] == ' '; k2++)
                {
                }
                if (i2 >= lines.Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                    return 0;
                }
                if (k2 >= lines[i2].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                    return 0;
                }
                //check if number
                int fff = 1;
                if ((lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                {
                    int k9 = k2;
                    for (; k2 < lines[i2].Count() && lines[i2][k2] != ' ' && lines[i2][k2] != ';'; k2++)
                    {
                        if (fff == 1 && lines[i2][k2] == '.' && k9 != k2)
                        {
                            var += lines[i2][k2];
                            fff = 0;
                        }
                        else if ((lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                        {

                            var += lines[i2][k2];
                        }
                        else
                        {
                            MessageBox.Show("error");
                            error = true;
                            return 0;
                        }
                    }
                    bool isParsable;
                    if (i5 == 0)
                    {
                        isParsable = float.TryParse(var, out varint1);
                    }
                    else
                    {
                        isParsable = float.TryParse(var, out varint2);

                    }
                    if (isParsable)
                    {
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("error");
                        return 0;
                    }

                    if (k2 > lines[i2].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        return 0;
                    }

                    //remove space
                    for (; lines[i2][k2] == ' '; k2++)
                    {
                    }

                    if (k2 > lines[i2].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        return 0;
                    }
                    if (lines[i2][k2] == ';' || lines[i2][k2] == ')' || lines[i2][k2] == '>' || lines[i2][k2] == '<' || lines[i2][k2] == '=' || lines[i2][k2] == '&'
                        || lines[i2][k2] == '|')
                    {
                        if (i5 == 0)
                        {
                            return varint1;
                        }
                        if (op == '+')
                            return varint1 + varint2;
                        if (op == '-')
                            return varint1 - varint2;
                        if (op == '*')
                            return varint1 * varint2;
                        if (op == '/')
                            return varint1 / varint2;
                    }
                    if (lines[i2][k2] == '+' || lines[i2][k2] == '-' || lines[i2][k2] == '*' || lines[i2][k2] == '/')
                    {
                        op = lines[i2][k2];
                        k2++;
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "");
                        return 0;
                    }
                    if (k2 > lines[i2].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        return 0;
                    }


                }
                else
                {
                    for (; k2 < lines[i2].Count() && lines[i2][k2] != ' ' && lines[i2][k2] != ';'; k2++)
                    {
                        if ((lines[i2][k2] >= 'a' && lines[i2][k2] <= 'z') ||
                            (lines[i2][k2] >= 'A' && lines[i2][k2] <= 'Z') ||
                            (lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                        {
                            var2 += lines[i2][k2];
                        }
                        else
                        {
                            MessageBox.Show("Error in line " + i2 + 1 + " You Cant use" + lines[i2][k2] + " in variable name");
                            error = true;
                            return 0;
                            break;

                        }
                    }

                    //check if name is exist before
                    int flag = 1;
                    for (int m = 0; m < allvariables.Count(); m++)
                    {
                        if (var2 == allint[m].name)
                        {
                            if (i5 == 0)
                            {
                                varint1 = allint[m].value;


                            }
                            else
                            {
                                varint2 = allint[m].value;
                            }
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        if (k2 > lines[i2].Count())
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                            return 0;
                        }

                        //remove space
                        for (; k2 < lines[i2].Count() && lines[i2][k2] == ' '; k2++)
                        {
                        }

                        if (k2 >= lines[i2].Count())
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + "the line not copmlet");
                            return 0;
                        }
                        if (lines[i2][k2] == ';' || lines[i2][k2] == ')' || lines[i2][k2] == '>' || lines[i2][k2] == '<' || lines[i2][k2] == '=' || lines[i2][k2] == '&'
                        || lines[i2][k2] == '|')
                        {
                            if (i5 == 0)
                            {
                                return varint1;
                            }
                            if (op == '+')
                                return varint1 + varint2;
                            if (op == '-')
                                return varint1 - varint2;
                            if (op == '*')
                                return varint1 * varint2;
                            if (op == '/')
                                return varint1 / varint2;
                        }
                        if (lines[i2][k2] == '+' || lines[i2][k2] == '-' || lines[i2][k2] == '*' || lines[i2][k2] == '/')
                        {
                            op = lines[i2][k2];
                            k2++;
                        }
                        else
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + 1 + "");
                            return 0;
                        }
                        if (k2 > lines[i2].Count())
                        {
                            error = true;
                            MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                        }
                    }
                    else
                    {
                        error = true;

                        MessageBox.Show("error in line  " + i2 + 1 + "the varible not found");
                        return 0;

                    }
                }

            }
            return 0;
        }

        bool getboolresalt(int k2, int i2)

        {
            string var = "";
            string var2 = "";
            bool varint1;
            //remove space
            for (; i2 < lines.Count() && k2 < lines[i2].Count() && lines[i2][k2] == ' '; k2++)
            {
            }
            if (i2 >= lines.Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i2 + 1 + "the line not copmlet");
                return false;
            }

            if (lines[i2].Count() > 4 && (k2 == 0 || lines[i2][k2 - 1] == ' ') &&
                (lines[i2][k2] == 't' && lines[i2][k2 + 1] == 'r' &&
                lines[i2][k2 + 2] == 'u' && lines[i2][k2 + 3] == 'e' && lines[i2][k2 + 4] == ';'))
            {
                return true;
            }
            else if (lines[i2].Count() > 4 && (k2 == 0 || lines[i2][k2 - 1] == ' ') &&
                (lines[i2][k2] == 'f' && lines[i2][k2 + 1] == 'a' &&
                lines[i2][k2 + 2] == 'l' && lines[i2][k2 + 3] == 's' && lines[i2][k2 + 4] == 'e' && lines[i2][k2 + 5] == ';'))
            {
                return false;
            }
            else
            {
                for (; k2 < lines[i2].Count() && lines[i2][k2] != ' ' && lines[i2][k2] != ';'; k2++)
                {
                    if ((lines[i2][k2] >= 'a' && lines[i2][k2] <= 'z') ||
                        (lines[i2][k2] >= 'A' && lines[i2][k2] <= 'Z') ||
                        (lines[i2][k2] >= '0' && lines[i2][k2] <= '9'))
                    {
                        var2 += lines[i2][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + i2 + 1 + " You Cant use" + lines[i2][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }

                //check if name is exist before
                int flag = 1;
                for (int m = 0; m < allbool.Count(); m++)
                {
                    if (var2 == allbool[m].name)
                    {

                        varint1 = allbool[m].value;


                        return varint1;
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    return false;
                }


                return false;
            }
            return false;

        }
        bool boolIdentifiers(int myi, int myk)

        {
            string dtype = "";
            int k2 = myk;
            string name = "";
            if (lines[myi].Count() < 5)
                return false;
            if (lines[myi].Count() > 4 && (k2 == 0 || lines[myi][k2 - 1] == ' ') &&
                (lines[myi][k2] == 'b' && lines[myi][k2 + 1] == 'o' &&
                lines[myi][k2 + 2] == 'o' && lines[myi][k2 + 3] == 'l'))
            {
                dtype = "bool";
                k2 = k2 + 4;
                MessageBox.Show("bool");
            }
            else
            {
                return false;
            }

            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }

            //cant star with number
            if (k2 > lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi][k2] >= '0' && lines[myi][k2] <= '9')
            {
                MessageBox.Show("Error in line" + myi + 1 + "The name cant begain with number");
                error = true;
                return false;

            }
            else
            {
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                for (; k2 < lines[myi].Count() && lines[myi][k2] != ' ' && lines[myi][k2] != ';'; k2++)
                {
                    if ((lines[myi][k2] >= 'a' && lines[myi][k2] <= 'z') ||
                        (lines[myi][k2] >= 'A' && lines[myi][k2] <= 'Z') ||
                        (lines[myi][k2] >= '0' && lines[myi][k2] <= '9'))
                    {
                        name += lines[myi][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + myi + 1 + " You Cant use" + lines[myi][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("erro in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                //check if name is not any Reserved Words
                if (name == "if" || name == "for" || name == "void" || name == "int" || name == "char" ||
                   name == "double" || name == "while" || name == "else" || name == "true" ||
                   name == "false" || name == "do" || name == "return" || name == "break" ||
                   name == "continue" || name == "end")
                {
                    MessageBox.Show("Error in line " + myi + 1 + "You cant use this variable name " + name);
                    //error = true;
                    return false;

                }
                //check if name is exist before
                int flag = 1;
                for (int m = 0; m < allvariables.Count(); m++)
                {
                    if (name == allvariables[m].name)
                    {
                        flag = 0;
                        break;
                    }
                }

                if (flag == 0)
                {
                    MessageBox.Show("Error in line" + myi + 1 + " name of variable is taken");
                    error = true;
                    return false;
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;

                    }
                    if (lines[myi][k2] == ';')
                    {
                        if (dtype == "bool")
                        {
                            boolvariable pnn = new boolvariable();
                            pnn.name = name;
                            pnn.datatype = "bool";
                            allvariables.Add(pnn);
                            allbool.Add(pnn);
                            richTextBox2.Text += "bool " + name + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                    }
                    else
                    {
                        //remove space
                        for (; lines[myi][k2] == ' '; k2++)
                        {
                        }
                        if (lines[myi][k2] == '=')
                        {
                            k2++;
                            ////////////////
                            bool valuo = getboolresalt(k2, myi);
                            if (error)
                            {
                                return false;
                            }
                            boolvariable pnn = new boolvariable();
                            pnn.name = name;
                            pnn.datatype = "bool";
                            pnn.value = valuo;
                            allvariables.Add(pnn);
                            allbool.Add(pnn);
                            richTextBox2.Text += name + " = " + valuo + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error in line" + myi + 1 + " we need = after name of varible");
                            error = true;
                        }


                    }
                }






            }

            return true;
        }
        bool boolIdentifiers2(int myi, int myk)

        {
            string dtype = "";
            int k2 = myk;
            string name = "";
            if (lines[myi].Count() < 4)
                return false;



            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }

            //cant star with number
            if (k2 > lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi][k2] >= '0' && lines[myi][k2] <= '9')
            {
                MessageBox.Show("Error in line" + myi + 1 + "The name cant begain with number");
                error = true;
                return false;

            }
            else
            {
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                for (; k2 < lines[myi].Count() && lines[myi][k2] != ' ' && lines[myi][k2] != ';'; k2++)
                {
                    if ((lines[myi][k2] >= 'a' && lines[myi][k2] <= 'z') ||
                        (lines[myi][k2] >= 'A' && lines[myi][k2] <= 'Z') ||
                        (lines[myi][k2] >= '0' && lines[myi][k2] <= '9'))
                    {
                        name += lines[myi][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + myi + 1 + " You Cant use" + lines[myi][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("erro in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                //check if name is not any Reserved Words
                if (name == "if" || name == "for" || name == "void" || name == "int" || name == "char" ||
                   name == "double" || name == "while" || name == "else" || name == "true" ||
                   name == "false" || name == "do" || name == "return" || name == "break" ||
                   name == "continue" || name == "end")
                {
                    MessageBox.Show("Error in line " + myi + 1 + "You cant use this variable name " + name);
                    //error = true;
                    return false;

                }
                //check if name is exist before
                int flag = 1;
                for (int m = 0; m < allvariables.Count(); m++)
                {
                    if (name == allvariables[m].name)
                    {
                        flag = 0;
                        break;
                    }
                }

                if (flag == 1)
                {
                    MessageBox.Show("Error in line" + myi + 1 + " name of variable is taken");
                    error = true;
                    return false;
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;

                    }
                    if (lines[myi][k2] == ';')
                    {

                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return true;

                    }
                    else
                    {
                        //remove space
                        for (; lines[myi][k2] == ' '; k2++)
                        {
                        }
                        if (lines[myi][k2] == '=')
                        {
                            k2++;
                            ////////////////
                            bool valuo = getboolresalt(k2, myi);
                            if (error)
                            {
                                return false;
                            }
                            boolvariable pnn = new boolvariable();
                            pnn.name = name;
                            pnn.datatype = "bool";
                            pnn.value = valuo;
                            allvariables.Add(pnn);
                            allbool.Add(pnn);
                            richTextBox2.Text += name + " = " + valuo + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error in line" + myi + 1 + " we need = after name of varible");
                            error = true;
                        }


                    }
                }






            }

            return true;
        }

        bool intIdentifiers(int myi, int myk)
        {
            string dtype = "";
            int k2 = myk;
            string name = "";
            if (lines[myi].Count() < 5)
                return false;
            if (lines[myi].Count() > 4 && (k2 == 0 || lines[myi][k2 - 1] == ' ') &&
                (lines[myi][k2] == 'i' && lines[myi][k2 + 1] == 'n' &&
                lines[myi][k2 + 2] == 't' && lines[myi][k2 + 3] == ' '))
            {
                dtype = "int";
                k2 = k2 + 3;
               // MessageBox.Show("int");
            }
            else
            {
                return false;
            }
            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }

            //cant start with number
            if (k2 > lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi][k2] >= '0' && lines[myi][k2] <= '9')
            {
                MessageBox.Show("Error in line" + myi + 1 + "The name cant begain with number");
                error = true;
                return false;

            }
            else
            {
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                for (; k2 < lines[myi].Count() && lines[myi][k2] != ' ' && lines[myi][k2] != ';'; k2++)
                {
                    if ((lines[myi][k2] >= 'a' && lines[myi][k2] <= 'z') ||
                        (lines[myi][k2] >= 'A' && lines[myi][k2] <= 'Z') ||
                        (lines[myi][k2] >= '0' && lines[myi][k2] <= '9'))
                    {
                        name += lines[myi][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + myi + 1 + " You Cant use" + lines[myi][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("erro in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                //check if name is not any Reserved Words
                if (name == "if" || name == "for" || name == "void" || name == "int" || name == "char" ||
                   name == "double" || name == "while" || name == "else" || name == "true" ||
                   name == "false" || name == "do" || name == "return" || name == "break" ||
                   name == "continue" || name == "end")
                {
                    MessageBox.Show("Error in line " + myi + 1 + "You cant use this variable name " + name);
                    error = true;
                    return false;

                }
                //check if name is exist before
                int flag = 1;
                for (int m = 0; m < allvariables.Count(); m++)
                {
                    if (name == allvariables[m].name)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 0)
                {
                    MessageBox.Show("Error in line" + myi + 1 + " name of variable is taken");
                    error = true;
                    return false;
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;

                    }
                    if (lines[myi][k2] == ';')
                    {
                        if (dtype == "int")
                        {
                            intvariable pnn = new intvariable();
                            pnn.name = name;
                            pnn.datatype = "int";
                            allvariables.Add(pnn);
                            allint.Add(pnn);
                            richTextBox2.Text += "int " + name + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                    }
                    else
                    {
                        //remove space
                        for (; lines[myi][k2] == ' '; k2++)
                        {
                        }
                        if (lines[myi][k2] == '=')
                        {
                            k2++;
                            int valuo = getintresalt(k2, myi);
                            if (error)
                            {
                                return false;
                            }
                            intvariable pnn = new intvariable();
                            pnn.name = name;
                            pnn.datatype = "int";
                            pnn.value = valuo;
                            allvariables.Add(pnn);
                            allint.Add(pnn);
                            richTextBox2.Text += name + " = " + valuo + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error in line" + myi + 1 + " we need = after name of varible");
                            error = true;
                        }

                    }
                }

            }
            return true;
        }
        bool floatIdentifiers(int myi, int myk)
        {
            string dtype = "";
            int k2 = myk;
            string name = "";
            if (lines[myi].Count() < 5)
                return false;
            if (lines[myi].Count() > 4 && (k2 == 0 || lines[myi][k2 - 1] == ' ') &&
                (lines[myi][k2] == 'f' && lines[myi][k2 + 1] == 'l' &&
                lines[myi][k2 + 2] == 'o' && lines[myi][k2 + 3] == 'a' && lines[myi][k2 + 4] == 't' && lines[myi][k2 + 5] == ' '))
            {
                dtype = "float";
                k2 = k2 + 5;
                MessageBox.Show("float");
            }
            else
            {
                return false;
            }
            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }

            //cant star with number
            if (k2 > lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi][k2] >= '0' && lines[myi][k2] <= '9')
            {
                MessageBox.Show("Error in line" + myi + 1 + "The name cant begain with number");
                error = true;
                return false;

            }
            else
            {
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                for (; k2 < lines[myi].Count() && lines[myi][k2] != ' ' && lines[myi][k2] != ';'; k2++)
                {
                    if ((lines[myi][k2] >= 'a' && lines[myi][k2] <= 'z') ||
                        (lines[myi][k2] >= 'A' && lines[myi][k2] <= 'Z') ||
                        (lines[myi][k2] >= '0' && lines[myi][k2] <= '9'))
                    {
                        name += lines[myi][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + myi + 1 + " You Cant use" + lines[myi][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("erro in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                //check if name is not any Reserved Words
                if (name == "if" || name == "for" || name == "void" || name == "int" || name == "char" ||
                   name == "double" || name == "while" || name == "else" || name == "true" ||
                   name == "false" || name == "do" || name == "return" || name == "break" ||
                   name == "continue" || name == "end")
                {
                    MessageBox.Show("Error in line " + myi + 1 + "You cant use this variable name " + name);
                    error = true;
                    return false;

                }
                //check if name is exist before
                int flag = 1;
                for (int m = 0; m < allvariables.Count(); m++)
                {
                    if (name == allvariables[m].name)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 0)
                {
                    MessageBox.Show("Error in line" + myi + 1 + " name of variable is taken");
                    error = true;
                    return false;
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;

                    }
                    if (lines[myi][k2] == ';')
                    {
                        if (dtype == "float")
                        {
                            floatvariable pnn = new floatvariable();
                            pnn.name = name;
                            pnn.datatype = "float";
                            allvariables.Add(pnn);
                            allfloat.Add(pnn);
                            richTextBox2.Text += "float " + name + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                    }
                    else
                    {
                        //remove space
                        for (; lines[myi][k2] == ' '; k2++)
                        {
                        }
                        if (lines[myi][k2] == '=')
                        {
                            k2++;
                            float valuo = getfloatresalt(k2, myi);
                            if (error)
                            {
                                return false;
                            }
                            floatvariable pnn = new floatvariable();
                            pnn.name = name;
                            pnn.datatype = "int";
                            pnn.value = valuo;
                            allvariables.Add(pnn);
                            allfloat.Add(pnn);
                            richTextBox2.Text += name + " = " + valuo + "\n";
                            //MessageBox.Show("int x"+"\n");
                            f2 = 0;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error in line" + myi + 1 + " we need = after name of varible");
                            error = true;
                        }

                    }
                }

            }
            return true;
        }
        bool floatIdentifiers2(int myi, int myk)
        {
            string dtype = "";
            int k2 = myk;
            string name = "";
            if (lines[myi].Count() < 5)
                return false;


            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }
            if (k2 >= lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            //cant star with number
            if (k2 > lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi][k2] >= '0' && lines[myi][k2] <= '9')
            {
                MessageBox.Show("Error in line" + myi + 1 + "The name cant begain with number");
                error = true;
                return false;

            }
            else
            {
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                for (; k2 < lines[myi].Count() && lines[myi][k2] != ' ' && lines[myi][k2] != ';'; k2++)
                {
                    if ((lines[myi][k2] >= 'a' && lines[myi][k2] <= 'z') ||
                        (lines[myi][k2] >= 'A' && lines[myi][k2] <= 'Z') ||
                        (lines[myi][k2] >= '0' && lines[myi][k2] <= '9'))
                    {
                        name += lines[myi][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + myi + 1 + " You Cant use" + lines[myi][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("erro in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                //check if name is not any Reserved Words
                if (name == "if" || name == "for" || name == "void" || name == "int" || name == "char" ||
                   name == "double" || name == "while" || name == "else" || name == "true" ||
                   name == "false" || name == "do" || name == "return" || name == "break" ||
                   name == "continue" || name == "end")
                {
                    MessageBox.Show("Error in line " + myi + 1 + "You cant use this variable name " + name);
                    error = true;
                    return false;

                }
                //check if name is exist before
                int flag = 1;
                for (int m = 0; m < allvariables.Count(); m++)
                {
                    if (name == allvariables[m].name)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    MessageBox.Show("Error in line" + myi + 1 + " name of variable is taken");
                    error = true;
                    return false;
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;

                    }
                    if (lines[myi][k2] == ';')
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;
                    }
                    else
                    {
                        //remove space
                        for (; lines[myi][k2] == ' '; k2++)
                        {
                        }
                        if (lines[myi][k2] == '=')
                        {
                            k2++;
                            float valuo = getfloatresalt(k2, myi);
                            if (error)
                            {
                                return false;
                            }
                            floatvariable pnn = new floatvariable();
                            pnn.name = name;
                            pnn.datatype = "int";
                            pnn.value = valuo;
                            allvariables.Add(pnn);
                            allfloat.Add(pnn);
                            richTextBox2.Text += name + " = " + valuo + "\n";
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error in line" + myi + 1 + " we need = after name of varible");
                            error = true;
                        }

                    }
                }

            }
            return true;
        }


        bool intIdentifiers2(int myi, int myk)
        {
            int m;
            float xm;

            string dtype = "";
            int k2 = myk;
            string name = "";

            if (k2 >= lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            //remove space
            for (; lines[myi][k2] == ' ' && k2 <= lines[myi].Count(); k2++)
            {
            }
            if (k2 >= lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            //cant star with number
            if (k2 > lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi][k2] >= '0' && lines[myi][k2] <= '9')
            {
                MessageBox.Show("Error in line" + myi + 1 + "The name cant begain with number");
                error = true;
                return false;

            }
            else
            {
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                for (; k2 < lines[myi].Count() && lines[myi][k2] != ' ' && lines[myi][k2] != ';'; k2++)
                {
                    if ((lines[myi][k2] >= 'a' && lines[myi][k2] <= 'z') ||
                        (lines[myi][k2] >= 'A' && lines[myi][k2] <= 'Z') ||
                        (lines[myi][k2] >= '0' && lines[myi][k2] <= '9'))
                    {
                        name += lines[myi][k2];
                    }
                    else
                    {
                        MessageBox.Show("Error in line " + myi + 1 + " You Cant use" + lines[myi][k2] + " in variable name");
                        error = true;
                        return false;
                        break;

                    }
                }
                if (k2 > lines[myi].Count())
                {
                    error = true;
                    MessageBox.Show("erro in line  " + myi + 1 + "the line not copmlet");
                    return false;
                }
                //check if name is not any Reserved Words
                if (name == "if" || name == "for" || name == "void" || name == "int" || name == "char" ||
                   name == "double" || name == "while" || name == "else" || name == "true" ||
                   name == "false" || name == "do" || name == "return" || name == "break" ||
                   name == "continue" || name == "end")
                {
                    return false;
                    MessageBox.Show("Error in line " + myi + 1 + "You cant use this variable name " + name);
                    error = true;
                    return false;

                }
                //check if name is exist before
                int flag = 1;
                for (m = 0; m < allint.Count(); m++)
                {
                    if (name == allint[m].name)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                {
                    MessageBox.Show("Error in line" + myi + 1 + " name of variable is notfound");
                    error = true;
                    return false;
                }
                else
                {
                    if (name == "")
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;

                    }
                    if (lines[myi][k2] == ';')
                    {
                        MessageBox.Show("Error in line" + myi + 1 + " name of variable is not found");
                        error = true;
                        return false;
                    }
                    else
                    {
                        //remove space
                        for (; lines[myi][k2] == ' '; k2++)
                        {
                        }
                        if (lines[myi][k2] == '=')
                        {
                            k2++;
                            int valuo = getintresalt(k2, myi);
                            if (error)
                            {
                                return false;
                            }

                            allint[m].value = valuo;

                            richTextBox2.Text += name + " = " + valuo + "\n";
                            f1 = 1;
                            //MessageBox.Show("int x"+"\n");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error in line" + myi + 1 + " we need = after name of varible");
                            error = true;
                        }

                    }
                }

            }
            f1 = 1;
            return true;
        }
        bool concheck(int var1, int var2, char op)
        {
            if (op == '=')
            {
                if (var1 == var2)
                {
                    return true;
                }
                return false;
            }
            if (op == '>')
            {
                if (var1 > var2)
                {
                    return true;
                }
                return false;
            }
            if (op == '<')
            {
                if (var1 < var2)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        bool ifcon()
        {
            int k2;
            char op = ' ';
            bool cond3 = true;
            if (i < lines.Count() && lines[i].Count() > 5 && (k == 0 || lines[i][k - 1] == ' ') &&
               (lines[i][k] == 'i' && lines[i][k + 1] == 'f'))
            {

            }
            else return false;
            k2 = k + 2;
            //remove space
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not complete");
                return false;
            }

            if (lines[i][k2] != '(')
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            k2++;
            //remove space
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            int valuo = getintresalt(k2, i);
            k2++;
            if (error)
            {
                return false;
            }
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + "the line not copmlet");
                return false;
            }
            if (lines[i][k2] == '>' || lines[i][k2] == '<' || (lines[i][k2] == '=' &&
                k2 + 1 < lines[i].Count() && lines[i][k2 + 1] == '='))
            {
                op = lines[i][k2];
                k2++;
                if (op == '=')
                {
                    k2++;
                }

            }
            else
            {
                error = true;
                MessageBox.Show("error in line  " + i + "the line not copmlet");
                return false;
            }
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + "the line not copmlet");
                return false;
            }
            int valuo2 = getintresalt(k2, i);
            if (error)
            {
                return false;
            }
            char op2 = ' ';
            bool cond = false;
            k2++;
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            if (lines[i][k2] == ')')
            {
                cond = concheck(valuo, valuo2, op);
                cond3 = cond;

                richTextBox2.Text += cond + "\n";

            }
            else if ((lines[i][k2] == '&' && lines[i][k2 + 1] == '&') || (lines[i][k2] == '|' && lines[i][k2 + 1] == '|'))
            {
                cond = concheck(valuo, valuo2, op);

                char op4 = ' ';
                op2 = lines[i][k2];
                k2++;
                k2++;
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                int valuo3 = getintresalt(k2, i);
                if (error)
                {
                    return false;
                }
                k2++;

                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + "the line not copmlet");
                    return false;
                }

                if (lines[i][k2] == '>' || lines[i][k2] == '<' || (lines[i][k2] == '=' && k2 + 1 < lines[i].Count() && lines[i][k2 + 1] == '='))
                {
                    op4 = lines[i][k2];
                    k2++;
                    if (op4 == '=')
                    {
                        k2++;
                    }
                }
                else
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                int valuo4 = getintresalt(k2, i);

                if (error)
                {
                    return false;
                }
                //op4 = ' ';
                bool cond2;
                k2++;
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                if (lines[i][k2] == ')')
                {
                    cond3 = false;
                    cond2 = concheck(valuo3, valuo4, op4);
                    if (op2 == '|')
                    {
                        cond3 = cond || cond2;
                    }
                    else
                        cond3 = cond && cond2;

                    richTextBox2.Text += cond3 + "\n";

                }
                else
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }


            }
            else
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            bool obrk = false;
            int fline = 0;
            for (int i2 = i + 1; i2 < lines.Count(); i2++)
            {

                for (int k3 = 0; k3 < lines[i2].Count(); k3++)

                {
                    if (lines[i2][k3] == '{')
                    {
                        obrk = true;
                        fline = i2 + 1;
                        break;
                    }
                }
                if (obrk)
                    break;
            }
            if (!obrk)
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "{");
                return false;
            }
            obrk = false;
            int lline = 0;
            for (int i2 = fline; i2 < lines.Count(); i2++)
            {

                for (int k3 = 0; k3 < lines[i2].Count(); k3++)

                {
                    if (lines[i2][k3] == '}')
                    {
                        obrk = true;
                        lline = i2 - 1;
                        break;
                    }
                }
                if (obrk)
                    break;
            }
            if (!obrk)
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "{");
                return false;
            }
            i = lline + 2;
            if (cond3)
            {
                for (int i2 = fline; i2 <= lline && i2 <= lines.Count(); i2++)
                {



                    bool error2 = !intIdentifiers(i2, 0);
                    if (error)
                    {
                        break;
                    }
                    if (f1 == 0)
                    {
                        error2 = !intIdentifiers2(i2, 0);
                        if (error)
                        {
                            break;
                        }
                    }

                }
                return false;

            }
            else
            {
                k2 = 0;
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + "the line not copmlet");
                    return false;
                }
                if ((k2 == 0 || lines[i][k2 - 1] == ' ') &&
                 (lines[i][k2] == 'e' && lines[i][k2 + 1] == 'l' &&
                lines[i][k2 + 2] == 's' && lines[i][k2 + 3] == 'e'))
                {
                    obrk = false;
                    fline = 0;
                    for (int i2 = i + 1; i2 < lines.Count(); i2++)
                    {

                        for (int k3 = 0; k3 < lines[i2].Count(); k3++)

                        {
                            if (lines[i2][k3] == '{')
                            {
                                obrk = true;
                                fline = i2 + 1;
                                break;
                            }
                        }
                        if (obrk)
                            break;
                    }
                    if (!obrk)
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "{");
                        return false;
                    }
                    obrk = false;
                    lline = 0;
                    for (int i2 = fline; i2 < lines.Count(); i2++)
                    {

                        for (int k3 = 0; k3 < lines[i2].Count(); k3++)

                        {
                            if (lines[i2][k3] == '}')
                            {
                                obrk = true;
                                lline = i2 - 1;
                                break;
                            }
                        }
                        if (obrk)
                            break;
                    }
                    if (!obrk)
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "{");
                        return false;
                    }
                    i = lline + 2;

                    for (int i2 = fline; i2 <= lline && i2 <= lines.Count(); i2++)
                    {



                        bool error2 = !intIdentifiers(i2, 0);
                        if (error)
                        {
                            break;
                        }
                        if (f1 == 0)
                        {
                            error2 = !intIdentifiers2(i2, 0);
                            if (error)
                            {
                                break;
                            }
                        }

                    }

                }
                return false;
            }
            f1 = 1;

            return true;
        }
        bool continue1(int myi, int myk)
        {
            int k2 = myk;
            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }

            if (k2 >= lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi].Count() > 8)
            {
                //continue;
                if (lines[myi].Count() > 5 && (k2 == 0 || lines[myi][k2 - 1] == ' ') &&
               (lines[myi][k2] == 'c' && lines[myi][k2 + 1] == 'o' && lines[myi][k2 + 2] == 'n' && lines[myi][k2 + 3] == 't'
               && lines[myi][k2 + 4] == 'i' && lines[myi][k2 + 5] == 'n' && lines[myi][k2 + 6] == 'u' && lines[myi][k2 + 7] == 'e'
               && lines[myi][k2 + 8] == ';'))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        bool break1(int myi, int myk)
        {
            int k2 = myk;
            //remove space
            for (; lines[myi][k2] == ' '; k2++)
            {
            }

            if (k2 >= lines[myi].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            if (lines[myi].Count() > 5)
            {
                //continue;
                if (lines[myi].Count() > 5 && (k2 == 0 || lines[myi][k2 - 1] == ' ') &&
               (lines[myi][k2] == 'b' && lines[myi][k2 + 1] == 'r' && lines[myi][k2 + 2] == 'e' && lines[myi][k2 + 3] == 'a'
               && lines[myi][k2 + 4] == 'k' && lines[myi][k2 + 5] == ';'))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        bool forcon()
        {
            bool bk2 = false;
            int k2;
            char op = ' ', op4 = ' ';
            bool cond4 = true, cond3 = true, cond2 = true;

            if (lines[i].Count() > 5 && (k == 0 || lines[i][k - 1] == ' ') &&
               (lines[i][k] == 'f' && lines[i][k + 1] == 'o' && lines[i][k + 2] == 'r'))
            {

            }
            else return false;
            k2 = k + 3;

            //remove space
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }

            if (lines[i][k2] != '(')
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            k2++;
            //remove space
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }
            intIdentifiers(i, k2);
            intIdentifiers2(i, k2);

            for (; lines[i][k2] != ';'; k2++)
            {
            }
            k2++;
            //remove space
            for (; lines[i][k2] == ' '; k2++)
            {
            }

            if (k2 > lines[i].Count())
            {
                error = true;
                MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                return false;
            }

            int myk = k2;
            int myi = i;
            cond3 = true;
            for (; cond3 && !bk2; k2 = myk)
            {
                i = myi;


                int valuo = getintresalt(k2, i);
                k2++;
                if (error)
                {
                    return false;
                }
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + "the line not copmlet");
                    return false;
                }
                if (lines[i][k2] == '>' || lines[i][k2] == '<' || (lines[i][k2] == '=' &&
                    k2 + 1 < lines[i].Count() && lines[i][k2 + 1] == '='))
                {
                    op = lines[i][k2];
                    k2++;
                    if (op == '=')
                    {
                        k2++;
                    }

                }
                else
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + "the line not copmlet");
                    return false;
                }
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + "the line not copmlet");
                    return false;
                }
                int valuo2 = getintresalt(k2, i);
                if (error)
                {
                    return false;
                }
                char op2 = ' ';
                bool cond = false;
                k2++;
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                if (lines[i][k2] == ';')
                {
                    cond = concheck(valuo, valuo2, op);
                    cond3 = cond;

                    richTextBox2.Text += cond + "\n";
                    k2++;
                    /////////////////////call right
                }
                else if ((lines[i][k2] == '&' && lines[i][k2 + 1] == '&') || (lines[i][k2] == '|' && lines[i][k2 + 1] == '|'))
                {
                    op4 = ' ';
                    cond2 = true;
                    op2 = lines[i][k2];
                    k2++;
                    k2++;
                    for (; lines[i][k2] == ' '; k2++)
                    {
                    }

                    if (k2 > lines[i].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                        return false;
                    }
                    int valuo3 = getintresalt(k2, i);
                    if (error)
                    {
                        return false;
                    }
                    k2++;

                    for (; lines[i][k2] == ' '; k2++)
                    {
                    }

                    if (k2 > lines[i].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + "the line not copmlet");
                        return false;
                    }

                    if (lines[i][k2] == '>' || lines[i][k2] == '<' || (lines[i][k2] == '=' && k2 + 1 < lines[i].Count() && lines[i][k2 + 1] == '='))
                    {
                        op4 = lines[i][k2];
                        k2++;
                        if (op4 == '=')
                        {
                            k2++;
                        }
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                        return false;
                    }
                    for (; lines[i][k2] == ' '; k2++)
                    {
                    }

                    if (k2 > lines[i].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                        return false;
                    }
                    int valuo4 = getintresalt(k2, i);

                    if (error)
                    {
                        return false;
                    }
                    //op4 = ' ';

                    k2++;
                    for (; lines[i][k2] == ' '; k2++)
                    {
                    }

                    if (k2 > lines[i].Count())
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                        return false;
                    }
                    if (lines[i][k2] == ';')
                    {
                        cond3 = false;
                        cond2 = concheck(valuo, valuo2, op4);
                        if (op2 == '|')
                        {
                            cond3 = cond || cond2;
                        }
                        else
                            cond3 = cond && cond2;

                        richTextBox2.Text += cond3 + "\n";
                        k2++;
                    }
                    else
                    {
                        error = true;
                        MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                        return false;
                    }


                }
                else
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                for (; lines[i][k2] == ' '; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                int rihti = i, rightk = k2;

                //intIdentifiers2(i, k2);
                if (error)
                {
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;
                }
                for (; lines[i][k2] == ' '; k2++)
                {
                }
                for (; lines[i][k2] != ')'; k2++)
                {
                }

                if (k2 > lines[i].Count())
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");

                    return false;
                }
                if (lines[i][k2] == ')')
                {
                    //cond3 = false;
                    //cond2 = concheck(valuo, valuo2, op4);
                    //if (op2 == '|')
                    //{
                    //    cond3 = cond || cond2;
                    //}
                    //else
                    //    cond3 = cond && cond2;

                    //richTextBox2.Text += cond3 + "\n";

                }
                else
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "the line not copmlet");
                    return false;


                }
                bool obrk = false;
                int fline = 0;
                for (int i2 = i + 1; i2 < lines.Count(); i2++)
                {

                    for (int k3 = 0; k3 < lines[i2].Count(); k3++)

                    {
                        if (lines[i2][k3] == '{')
                        {
                            obrk = true;
                            fline = i2 + 1;
                            break;
                        }
                    }
                    if (obrk)
                        break;
                }
                if (!obrk)
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "{");
                    return false;
                }
                obrk = false;
                int lline = 0;
                for (int i2 = fline; i2 < lines.Count(); i2++)
                {

                    for (int k3 = 0; k3 < lines[i2].Count(); k3++)

                    {
                        if (lines[i2][k3] == '}')
                        {
                            obrk = true;
                            lline = i2 - 1;
                            break;
                        }
                    }
                    if (obrk)
                        break;
                }
                if (!obrk)
                {
                    error = true;
                    MessageBox.Show("error in line  " + i + 1 + "{");
                    return false;
                }
                i = lline + 2;
                if (cond3)
                {

                    for (int i2 = fline; i2 <= lline && i2 <= lines.Count(); i2++)
                    {


                        f1 = 0;
                        bool brk1 = break1(i2, 0);
                        if (brk1 == true)
                        {
                            bk2 = true;
                            break;
                        }
                        bool brk3 = continue1(i2, 0);
                        if (brk1 == true)
                        {
                            break;
                        }
                        bool error2 = !intIdentifiers(i2, 0);
                        if (error)
                        {
                            break;
                        }
                        if (f1 == 0)
                        {
                            error2 = !intIdentifiers2(i2, 0);
                            if (error)
                            {
                                break;
                            }
                        }

                    }
                    if (!bk2)
                    {
                        intIdentifiers2(rihti, rightk);
                    }

                }
            }





            f1 = 1;



            return true;
        }

    }
}
