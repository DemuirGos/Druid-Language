﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YetAnotherScriptingLanguage
{
    class Interpreter
    {
        private string _script;
        private TranslationUnit Local;
        private Parser main;
        private static Dictionary<string, Function> Functions = new Dictionary<string, Function>();
        private static Dictionary<string, Action> Actions = new Dictionary<string, Action>();
        public Interpreter(string script)
        {
            _script = script;
            Initialize();
        }
        public void Initialize()
        {
            main = new Parser(Local.Tokens);
        }
        public void SetUp(KeyWords dictionary)
        {
            foreach(var word in dictionary)
            {
                switch (word.Value)
                {
                    case ("If"): 
                        Interpreter.Functions.Add("If", new IfProcess("",new TokensList(),0));
                        break;
                    case ("While"):
                        Interpreter.Functions.Add("While", new WhileProcess("", new TokensList(), 0));
                        break;
                    case ("Print"):
                        Interpreter.Functions.Add("Print", new PrintProcess());
                        break;
                    case ("Read"):
                        Interpreter.Functions.Add("Read", new ReadProcess());
                        break;
                    case ("Return"):
                        Interpreter.Functions.Add("Return", new ReturnProcess());
                        break;
                    case ("Variable"):
                        Interpreter.Functions.Add("Variable", new VariableProcess());
                        break;
                    case ("For"):
                        Interpreter.Functions.Add("For", new ForProcess("", new TokensList(), 0));
                        break;
                    case ("Import"):
                        Interpreter.Functions.Add("Import", new ImportProcess());
                        break;
                    case ("Class"):
                        Interpreter.Functions.Add("Class", new ClassProcess());
                        break;
                    case ("Function"):
                        Interpreter.Functions.Add("Function", new FunctionProcess());
                        break;
                }
            }
        }
    }
}
