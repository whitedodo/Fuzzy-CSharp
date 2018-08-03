/*
 * Program.cs
 * Created by Dodo
 * User: Dodo(rabbit.white@daum.net)
 * Date: 2017-11-29
 * Time: 오후 8:21
 */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Airconditioner
{
	class Program
	{
		public static void Main(string[] args)
		{		
			
			double[] sample = {22.3, 22.4, 22.5, 22.3, 22.5, 22.4, 22.6};
			double changeVal = 0.0;
			
			int roomID = -1;
			int action = -1;
			
			var fuzzy = new Fuzzy();	// 퍼지 생성
			
			var pFuzzyList = new ArrayList();
			var pMidList = new List<double>();
			
			// 사용자 목표
			Enum target = Fuzzy.TARGET.VERY_COLD;
			
			// 무한 루프 가정
			foreach ( double temperature in sample )
			{
				// 퍼지 동작
				fuzzy.setupTemperature( temperature + changeVal );
				
				roomID = fuzzy.minTempID();	// Min-Max의 Min 기법
				action = fuzzy.getAction(roomID, target);
				
				FuzzyNode[] fuzzyNode = fuzzy.getNode();
				
				Console.WriteLine( temperature + ":Action=" + (Fuzzy.ACTION)action );
				
								
				pMidList.Add(fuzzyNode[roomID].getValue());
				pFuzzyList.Add( fuzzyNode );
				
			}
			
			// 비퍼지화(무게중심법)
			fuzzy.defuzzification(sample, pMidList);
			
			//Console.WriteLine( room_id + "/" + action );
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}