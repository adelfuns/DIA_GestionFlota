using System;
namespace DIA_GestionFlota
{
	/// <summary>
    /// Consola de manejo de la consola.
    /// </summary>
    public static class Consola
    {
		/// <summary>
        /// Escribe el msg especificado.
        /// </summary>
        /// <param name="msg">El mensaje como string.</param>
        public static void Escribe(string msg)
		{
			Console.WriteLine(msg);
		}
    }
}
