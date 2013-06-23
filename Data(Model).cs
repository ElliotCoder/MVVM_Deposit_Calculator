using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;

namespace MVVM_Sample
{
    class Data_Model_ 
    {
        //Данные
        UInt32 startingSum = 0,
            endSum = 0;
        UInt16 periods = 0;
        float percentage = 0;
        List<ExpressionWrapper> expressions;

        public Data_Model_()
        {
            expressions = new List<ExpressionWrapper>();
            expressions.Add(new ExpressionWrapper("Сложный процент",
                    "Сумма = Начальная сумма * (1 + %) ^ Количество периодов", Expressions.ComplexPercent));
            expressions.Add( new ExpressionWrapper("Простой процент",
                    "Сумма = Начальная сумма * Количество периодов * %", Expressions.SimplePercent));
        }

        public List<ExpressionWrapper> ExpressionsList
        {
            get { return expressions; }
            set { expressions = value; }
        }

        public UInt32 StartingSum
        {
            get { return startingSum; }
            set { startingSum = value; }
        }

        public UInt16 Periods
        {
            get { return periods; }
            set { periods = value; }
        }

        public UInt32 EndSum
        {
            get { return endSum; }
            set { endSum = value; }
        }

        public float Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }
    }
}
