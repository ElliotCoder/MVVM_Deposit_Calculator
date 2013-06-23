using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM_Sample
{
    //Делегат функции расчёта депозита
    public delegate double Expression(UInt32 Sum, float percentage, UInt16 periods);
    //Статический клас с методами расчета депозита
    public static class Expressions
    {
        public static Double ComplexPercent(UInt32 Sum, float percentage, UInt16 periods)
        {
            return Sum * Math.Pow((1.0f + percentage / 100), periods);
        }

        public static Double SimplePercent(UInt32 Sum, float percentage, UInt16 periods)
        {
            return Sum * (1 + percentage / 100 * periods);
        }
    }
    //Обёртка метода расчета (название, описание, делегат)
    public class ExpressionWrapper
    {
        String name, description;
        Expression expression;

        public ExpressionWrapper(String name, String shortDescription, Expression expression)
        {
            this.name = name;
            description = shortDescription;
            this.expression = expression;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public Expression DepositPercentExpression
        {
            get { return expression; }
        }
    }
}
