/*
 * Copyright (c) 2018 Evan Kale
 * Email: EvanKale91@gmail.com
 * Web: www.youtube.com/EvanKale
 * Social: @EvanKale91
 *
 * This file is part of AlienBeacon.
 *
 * AlienBeacon is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace AlienBacon
{
	class Debug
	{
		//
		// Summary:
		//     Writes the specified string value to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(string value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified object to the standard output
		//     stream.
		//
		// Parameters:
		//   value:
		//     The value to write, or null.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(object value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 64-bit unsigned integer value
		//     to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		[CLSCompliant(false)]
		public static void Write(ulong value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 64-bit signed integer value to
		//     the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(long value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified objects to the standard output
		//     stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg0:
		//     The first object to write using format.
		//
		//   arg1:
		//     The second object to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void Write(string format, object arg0, object arg1)
		{
#if DEBUG
			Console.Write(format,arg0,arg1);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 32-bit signed integer value to
		//     the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(int value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified object to the standard output
		//     stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg0:
		//     An object to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void Write(string format, object arg0)
		{
#if DEBUG
			Console.Write(format, arg0);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 32-bit unsigned integer value
		//     to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		[CLSCompliant(false)]
		public static void Write(uint value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		[CLSCompliant(false)]
		public static void Write(string format, object arg0, object arg1, object arg2, object arg3)
		{
#if DEBUG
			Console.Write(format, arg0, arg1, arg2, arg3);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified array of objects to the standard
		//     output stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg:
		//     An array of objects to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format or arg is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void Write(string format, params object[] arg)
		{
#if DEBUG
			Console.Write(format, arg);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified Boolean value to the standard
		//     output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(bool value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the specified Unicode character value to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(char value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the specified array of Unicode characters to the standard output stream.
		//
		// Parameters:
		//   buffer:
		//     A Unicode character array.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(char[] buffer)
		{
#if DEBUG
			Console.Write(buffer);
#endif
		}
		//
		// Summary:
		//     Writes the specified subarray of Unicode characters to the standard output stream.
		//
		// Parameters:
		//   buffer:
		//     An array of Unicode characters.
		//
		//   index:
		//     The starting position in buffer.
		//
		//   count:
		//     The number of characters to write.
		//
		// Exceptions:
		//   T:System.ArgumentNullException:
		//     buffer is null.
		//
		//   T:System.ArgumentOutOfRangeException:
		//     index or count is less than zero.
		//
		//   T:System.ArgumentException:
		//     index plus count specify a position that is not within buffer.
		//
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(char[] buffer, int index, int count)
		{
#if DEBUG
			Console.Write(buffer,index,count);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified objects to the standard output
		//     stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg0:
		//     The first object to write using format.
		//
		//   arg1:
		//     The second object to write using format.
		//
		//   arg2:
		//     The third object to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void Write(string format, object arg0, object arg1, object arg2)
		{
#if DEBUG
			Console.Write(format, arg0, arg1, arg2);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified System.Decimal value to the standard
		//     output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(decimal value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified single-precision floating-point
		//     value to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(float value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified double-precision floating-point
		//     value to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void Write(double value)
		{
#if DEBUG
			Console.Write(value);
#endif
		}
		//
		// Summary:
		//     Writes the current line terminator to the standard output stream.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine()
		{
#if DEBUG
			Console.WriteLine();
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified single-precision floating-point
		//     value, followed by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(float value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 32-bit signed integer value,
		//     followed by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(int value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 32-bit unsigned integer value,
		//     followed by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		[CLSCompliant(false)]
		public static void WriteLine(uint value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 64-bit signed integer value,
		//     followed by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(long value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified 64-bit unsigned integer value,
		//     followed by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		[CLSCompliant(false)]
		public static void WriteLine(ulong value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified object, followed by the current
		//     line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(object value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the specified string value, followed by the current line terminator, to
		//     the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(string value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified object, followed by the current
		//     line terminator, to the standard output stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg0:
		//     An object to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void WriteLine(string format, object arg0)
		{
#if DEBUG
			Console.WriteLine(format,arg0);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified objects, followed by the current
		//     line terminator, to the standard output stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg0:
		//     The first object to write using format.
		//
		//   arg1:
		//     The second object to write using format.
		//
		//   arg2:
		//     The third object to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void WriteLine(string format, object arg0, object arg1, object arg2)
		{
#if DEBUG
			Console.WriteLine(format,  arg0,  arg1,  arg2);
#endif
		}
		[CLSCompliant(false)]
		public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
		{
#if DEBUG
			Console.WriteLine(format,  arg0,  arg1,  arg2,  arg3);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified array of objects, followed by
		//     the current line terminator, to the standard output stream using the specified
		//     format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg:
		//     An array of objects to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format or arg is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void WriteLine(string format, params object[] arg)
		{
#if DEBUG
			Console.WriteLine(format, arg);
#endif
		}
		//
		// Summary:
		//     Writes the specified subarray of Unicode characters, followed by the current
		//     line terminator, to the standard output stream.
		//
		// Parameters:
		//   buffer:
		//     An array of Unicode characters.
		//
		//   index:
		//     The starting position in buffer.
		//
		//   count:
		//     The number of characters to write.
		//
		// Exceptions:
		//   T:System.ArgumentNullException:
		//     buffer is null.
		//
		//   T:System.ArgumentOutOfRangeException:
		//     index or count is less than zero.
		//
		//   T:System.ArgumentException:
		//     index plus count specify a position that is not within buffer.
		//
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(char[] buffer, int index, int count)
		{
#if DEBUG
			Console.WriteLine(buffer, index, count);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified System.Decimal value, followed
		//     by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(decimal value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the specified array of Unicode characters, followed by the current line
		//     terminator, to the standard output stream.
		//
		// Parameters:
		//   buffer:
		//     A Unicode character array.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(char[] buffer)
		{
#if DEBUG
			Console.WriteLine(buffer);
#endif
		}
		//
		// Summary:
		//     Writes the specified Unicode character, followed by the current line terminator,
		//     value to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(char value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified Boolean value, followed by the
		//     current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(bool value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified objects, followed by the current
		//     line terminator, to the standard output stream using the specified format information.
		//
		// Parameters:
		//   format:
		//     A composite format string (see Remarks).
		//
		//   arg0:
		//     The first object to write using format.
		//
		//   arg1:
		//     The second object to write using format.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		//
		//   T:System.ArgumentNullException:
		//     format is null.
		//
		//   T:System.FormatException:
		//     The format specification in format is invalid.
		public static void WriteLine(string format, object arg0, object arg1)
		{
#if DEBUG
			Console.WriteLine(format, arg0, arg1);
#endif
		}
		//
		// Summary:
		//     Writes the text representation of the specified double-precision floating-point
		//     value, followed by the current line terminator, to the standard output stream.
		//
		// Parameters:
		//   value:
		//     The value to write.
		//
		// Exceptions:
		//   T:System.IO.IOException:
		//     An I/O error occurred.
		public static void WriteLine(double value)
		{
#if DEBUG
			Console.WriteLine(value);
#endif
		}
	}
}
