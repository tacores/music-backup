using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    /// <summary>
    /// This interface represents a simple text file reader/writer. 
    /// </summary>
    public interface TextFileReadWriter
    {
        /// <summary>
        /// Read a text file and returns whole content at once.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <returns>Whole file content.</returns>
        string read(string filePath);

        /// <summary>
        /// Write to a text file.
        /// If the file is not empty, existing content is cleared.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <param name="content">The content that you want to write to.</param>
        void write(string filePath, string content);
    }
}
