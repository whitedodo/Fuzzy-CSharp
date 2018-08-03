/*
 * Fuzzy.cs
 * Created by Dodo
 * User: Dodo(rabbit.white@daum.net)
 * Date: 2017-11-30
 * Time: 오후 1:56
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Airconditioner
{
	/// <summary>
	/// Description of Knowledge.
	/// </summary>
	public class Fuzzy : IFuzzy
	{
	
		public enum TARGET {VERY_COLD, COLD, WARM, HOT, VERY_HOT}
		public enum ACTION {HEAT, COOL, NOCHANGE}
		
		private FuzzyNode[] pNode{ get; set; }

		public Fuzzy()
		{
			pNode = null;
		}
		
		public void setupTemperature(double temperature){
			
			var func = new Function();
			pNode = new FuzzyNode[ Enum.GetNames(typeof(Function.MEMBER)).Length ];
			
			for ( int i = 0; i < pNode.Length; i++ )
				pNode[i] = new FuzzyNode( (Function.MEMBER)i, func.calc( temperature, (Function.MEMBER)i ) );
			
		}
		
		public void reset(){
		
			for ( int i = 0; i < pNode.Length; i++ )
				pNode[i] = null;
			
		}
		
		public FuzzyNode[] getNode(){
			return pNode;
		}
		
		public int minTempID(){
			
			var id = new Queue<int>();
			
			int i = 0;
			
			for ( i = 0; i < pNode.Length; i++)
			{
				if ( System.Convert.ToDecimal( pNode[i].getValue() ) != 0 )
					id.Enqueue( i );
			}
			
			// ID 반환
			if ( id.Count == 1 )
				return id.Dequeue();
			
			else if ( id.Count == 2 )
			{
				int leftSide = id.Dequeue();
				int rightSide = id.Dequeue();
				int minSide = -1;
				double minValue = Math.Min( pNode[leftSide].getValue(), pNode[rightSide].getValue() );
				
				//Console.WriteLine("fullside(left):" + leftSide + ":" + arrValue[leftSide]);
				//Console.WriteLine("fullside(mid):" + minValue);
				//Console.WriteLine("fullside(right):" + rightSide + ":" + arrValue[rightSide]);
				
				if ( decimal.Compare(Convert.ToDecimal(minValue), Convert.ToDecimal(pNode[leftSide].getValue() ) ) == 0 )
				{
					minSide = leftSide;
					//Console.WriteLine("leftside:" + leftSide + ":" + minValue + "/" + arrValue[leftSide]);
				} // end of if
				
				if ( decimal.Compare(Convert.ToDecimal(minValue), Convert.ToDecimal(pNode[rightSide].getValue() ) ) == 0 )
				{
					minSide = rightSide;
					//Console.WriteLine("rightside:" + rightSide + "/" + minValue + "/" + arrValue[rightSide]);
				} // end of if
				
				return minSide;
			} // end of if
			
			return -1;
		}
		
		
		public int getAction(int roomID, Enum target){
			
			int result = -1;
			
			var id = (Function.MEMBER)roomID;
			
			// 25가지 조건
			switch (id) {
				
				case Function.MEMBER.N:
					
					if ( target.CompareTo(TARGET.VERY_COLD) == 0 ){
						result = (int)ACTION.NOCHANGE;
					}
					
					if( target.CompareTo(TARGET.COLD) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					if( target.CompareTo(TARGET.WARM) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					if( target.CompareTo(TARGET.HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					if( target.CompareTo(TARGET.VERY_HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					break;
					
				case Function.MEMBER.MN:
					
					if ( target.CompareTo(TARGET.VERY_COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.COLD) == 0 ){
						result = (int)ACTION.NOCHANGE;
					}
					
					if( target.CompareTo(TARGET.WARM) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					if( target.CompareTo(TARGET.HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					if( target.CompareTo(TARGET.VERY_HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					break;
					
				case Function.MEMBER.S:
					
					if ( target.CompareTo(TARGET.VERY_COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.WARM) == 0 ){
						result = (int)ACTION.NOCHANGE;
					}
					
					if( target.CompareTo(TARGET.HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					if( target.CompareTo(TARGET.VERY_HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					break;
					
				case Function.MEMBER.MP:
					
					if ( target.CompareTo(TARGET.VERY_COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.WARM) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.HOT) == 0 ){
						result = (int)ACTION.NOCHANGE;
					}
					
					if( target.CompareTo(TARGET.VERY_HOT) == 0 ){
						result = (int)ACTION.HEAT;
					}
					
					break;
					
				case Function.MEMBER.LP:
					
					if ( target.CompareTo(TARGET.VERY_COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.COLD) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.WARM) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.HOT) == 0 ){
						result = (int)ACTION.COOL;
					}
					
					if( target.CompareTo(TARGET.VERY_HOT) == 0 ){
						result = (int)ACTION.NOCHANGE;
					}
					
					break;
					
			}
			
			return result;
			
		}
		
		public void defuzzification(IEnumerable<double> arrX, IEnumerable<double> arrY){
			
			double upper = 0;
			double lower = 0;
			double formula = 0;
			double result = 0;
			
			foreach ( double x in arrX ){
				
				foreach (double y in arrY) {
					formula = Convert.ToDouble( decimal.Multiply( Convert.ToDecimal( x ), Convert.ToDecimal( y ) ) );
					upper = Convert.ToDouble( decimal.Add( Convert.ToDecimal( upper ), Convert.ToDecimal( formula ) ) );
					
					lower = Convert.ToDouble( decimal.Add( Convert.ToDecimal( lower ), Convert.ToDecimal( y ) ) );
				}
				
			}
			
			result = upper / lower;
			
			Console.WriteLine("야호" + result);
			
		}
		
		
	}
}