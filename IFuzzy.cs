/*
 * IFuzzy.cs
 * Created by Dodo
 * User: Dodo(rabbit.white@daum.net)
 * Date: 2017-11-30
 * Time: 오후 8:39
 * 
 */
using System;
using System.Collections.Generic;

namespace Airconditioner
{
	/// <summary>
	/// Description of IFuzzy.
	/// </summary>
	public interface IFuzzy
	{
		void setupTemperature(double temperature);
		void reset();
		FuzzyNode[] getNode();
		int minTempID();
		int getAction(int roomID, Enum target);
		void defuzzification(IEnumerable<double> arrX, IEnumerable<double> arrY);
	}
}
