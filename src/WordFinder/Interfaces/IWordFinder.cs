using System.Collections.Generic;
using System.Linq;
using System;

namespace WordFinder.Interfaces;
public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordstream);
}