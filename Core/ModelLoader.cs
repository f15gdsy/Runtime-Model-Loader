using UnityEngine;
using System.Collections;
using System.IO;

namespace RuntimeModelLoader {

	public class ModelLoader {

		public static Mesh Load (string path) {
			if (!File.Exists(path)) return null;

			string[] parts = path.Split(new []{"."}, System.StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length < 2) {	// No file extension
				return null;
			}

			ParserBase parser = null;

			string extention = parts[1];
			switch (extention) {
			case "obj":
				parser = new ObjParser();
				break;
			}

			Mesh mesh = parser.Parse(path);

			return mesh;
		}
	}

}