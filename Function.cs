/*
 * Function.cs
 * Created by Dodo
 * User: Dodo(rabbit.white@daum.net)
 * Date: 2017-11-29
 * Time: 오후 8:22
 * 
 */
using System;

namespace Airconditioner
{
	/// <summary>
	/// Description of function.
	/// </summary>
	public class Function
	{
		public enum MEMBER{N, MN, S, MP, LP}
		
		public Function()
		{
		}
		
		public double calc(double temperature, MEMBER type){
			
			decimal result = 0;
			// 
			switch (type) {
				
				case MEMBER.N:
					
					if ( temperature > -2.195122 && temperature <= 10 )
						result = decimal.Add( decimal.Multiply(-0.082m, System.Convert.ToDecimal (temperature)), 0.82m);
					else if ( temperature <= -2.195122 )
						result = 1;
					
					
					break;
					
				case MEMBER.MN:
					
					if ( temperature >= 0 && temperature <= 10 ){
						result = decimal.Multiply(0.1m, System.Convert.ToDecimal (temperature));
					}
					else if ( temperature >= 10 && temperature <= 20 ){
						result = decimal.Add( decimal.Multiply(-0.1m, System.Convert.ToDecimal (temperature)), 2);
					}
					
					break;
					
				case MEMBER.S:
					
					if ( temperature >= 10 && temperature <= 20 ){
						result = decimal.Add( decimal.Multiply(0.08m, System.Convert.ToDecimal (temperature)), -0.8m);
					}
					else if ( temperature >= 20 && temperature <= 30 ){
						result = decimal.Add( decimal.Multiply(-0.08m, System.Convert.ToDecimal (temperature)), 2.4m);
					}
					
					break;
					
				case MEMBER.MP:
					
					if ( temperature >= 20 && temperature <= 30 ){
						result = decimal.Add( decimal.Multiply(0.084m, System.Convert.ToDecimal (temperature)), -1.68m);
					}
					else if ( temperature >= 30 && temperature <= 40 ){
						result = decimal.Add( decimal.Multiply(-0.084m, System.Convert.ToDecimal (temperature)), 3.36m);
					}
					
					break;
					
				case MEMBER.LP:
					if ( temperature >= 30 && temperature <= 40 ){
						result = decimal.Add( decimal.Multiply(0.074m, System.Convert.ToDecimal (temperature)), -2.22m);
					}
					else if ( temperature > 40 )
						result = 1;
					
					break;
					
			} // end of switch
			
			return System.Convert.ToDouble( result );
			
		}
		
	}
}
