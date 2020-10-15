﻿using System;

namespace MMNet.CSh.ConsoleApp
{
	/// <summary>
	/// Tools for handling console input from the user.
	/// </summary>
	public static partial class Input
	{
		#region Integer Requests
		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static int RequestInt(string msg)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue) 
			{
				ret = TryInt(msg);
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="limit">A positive or negative limit on input. Sets the upper or lower bounds. 0 is treated as an upper bound.</param>
		public static int RequestInt(string msg, int limit)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue)
			{
				ret = TryInt(msg);
				if (ret == int.MinValue) { continue; }
				if (limit >= 0 && ret >= limit) {
					Console.WriteLine($"Input was higher than acceptable limit. Please enter a value below {limit}.");
					ret = int.MinValue;
				}
				else if (limit < 0 && ret <= limit) {
					Console.WriteLine($"Input was lower than acceptable limit. Please enter a value above {limit}.");
					ret = int.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="low">The lower bounds on a range of acceptable values.</param>
		/// <param name="high">The upper bounds on a range of acceptable values.</param>
		public static int RequestInt(string msg, int low, int high)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue)
			{
				ret = TryInt(msg);
				if (ret == int.MinValue) { continue; }
				if (ret < low || ret > high) {
					Console.WriteLine($"Input was outside the acceptable range of {low} to {high}.");
					ret = int.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="set">A set of acceptable values to compare user input against.</param>
		public static int RequestInt(string msg, int[] set)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue)
			{
				ret = TryInt(msg);
				if (ret == int.MinValue) { continue; }
				bool accept = false;
				foreach(int i in set) {
					if (ret == i) {
						accept = true;
						break;
					}
				}

				if (!accept) {
					Console.WriteLine($"Input did not match any acceptable values.");
					ret = int.MinValue;
				}
			}

			return ret;
		}

		private static int TryInt(string msg)
		{
			Console.WriteLine(msg);
			try {
				int ret = Convert.ToInt32(Console.ReadLine());
				if (ret == int.MinValue) {
					throw new OverflowException();
				}
				return ret;
			}
			catch (OverflowException){
				Console.WriteLine("Input was out of integer range. Please enter a positive or negative value below 2,147,483,648");
			}
			catch(FormatException) {
				Console.WriteLine("Input contained characters other than digits. Please enter only a number.");
			}

			return default;
		}
		#endregion

		#region Double Requests
		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static double RequestDouble(string msg)
		{
			double ret = double.MinValue;
			while(ret == double.MinValue)
			{
				ret = TryDouble(msg);
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="limit">A positive or negative limit on input. Sets the upper or lower bounds. 0 is treated as an upper bound.</param>
		public static double RequestDouble(string msg, double limit)
		{
			double ret = double.MinValue;
			while (ret == double.MinValue)
			{
				ret = TryDouble(msg);
				if (ret == double.MinValue) { continue; }
				if (limit >= 0 && ret >= limit) {
					Console.WriteLine($"Input was higher than acceptable limit. Please enter a value below {limit}.");
					ret = double.MinValue;
				}
				else if (limit < 0 && ret <= limit) {
					Console.WriteLine($"Input was lower than acceptable limit. Please enter a value above {limit}.");
					ret = double.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="low">The lower bounds on a range of acceptable values.</param>
		/// <param name="high">The upper bounds on a range of acceptable values.</param>
		public static double RequestDouble(string msg, double low, double high)
		{
			double ret = double.MinValue;
			while (ret == double.MinValue)
			{
				ret = TryDouble(msg);
				if (ret == double.MinValue) { continue; }
				if (ret < low || ret > high) {
					Console.WriteLine($"Input was outside the acceptable range of {low} to {high}.");
					ret = double.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="set">A set of acceptable values to compare user input against.</param>
		/// <param name="prec">A range to consider equivalency between user input and values in the set.</param>
		public static double RequestDouble(string msg, double[] set, double prec)
		{
			double ret = double.MinValue;
			prec = Math.Abs(prec);
			while (ret == double.MinValue)
			{
				ret = TryDouble(msg);
				if (ret == double.MinValue) { continue; }
				bool accept = false;
				foreach(double d in set) {
					if (ret <= d + prec && ret >= d - prec) {
						accept = true;
						break;
					}
				}

				if (!accept) {
					Console.WriteLine($"Input did not match any acceptable values.");
					ret = double.MinValue;
				}
			}

			return ret;
		}

		private static double TryDouble(string msg)
		{
			Console.WriteLine(msg);
			try {
				double ret = Convert.ToDouble(Console.ReadLine());
				if (ret == double.MinValue) {
					throw new OverflowException();
				}
				return ret;
			}
			catch(OverflowException) {
				Console.WriteLine("Input was out of floating point precision range.");
			}
			catch(FormatException) {
				Console.WriteLine("Input contained characters other than digits. Please enter only a number. It can contain one decimal point.");
			}

			return default;
		}
		#endregion

		#region String Requests
		public static float RequestString()
		{
			throw new NotImplementedException();
		}

		public static float RequestString(int limit)
		{
			throw new NotImplementedException();
		}

		public static float RequestString(int low, int high)
		{
			throw new NotImplementedException();
		}

		public static float RequestString(string[] set)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Boolean Requests
		public static bool RequestBool()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}