/* 
 * FuzzyNode.cs
 * Created by Dodo
 * User: Dodo(rabbit.white@daum.net)
 * Date: 2017-11-30
 * Time: 오후 6:43
 * 
 */
using System;

namespace Airconditioner
{
	/// <summary>
	/// Description of FuzzyNode.
	/// </summary>
	public class FuzzyNode
	{
		
		private Enum id {get; set;}
		private double value {get; set;}
		
		public FuzzyNode(Enum id, double value)
		{
			this.id = id;
			this.value = value;
		}
		
		public Enum getID(){
			return id;
		}
		
		public double getValue(){
			return value;
		}
	}
}
