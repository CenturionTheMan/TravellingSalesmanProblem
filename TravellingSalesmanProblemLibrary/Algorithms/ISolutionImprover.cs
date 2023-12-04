using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

public interface ISolutionImprover
{
    public void OnShowCurrentSolutionInIntervals(TimeSpan intervalLength, Action<int?, long> toInvoke);
    public void UnSubscribeShowCurrentSolutionInIntervals(Action<int?, long> toInvoke);
    public int? GetCurrentSolutionCost();
}
