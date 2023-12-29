using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary;

//public enum AlgorithmKind
//{
//    BRUTE_FORCE,
//    DYNAMIC_PROGRAMMING,
//    BRANCH_AND_BOUND,
//}

public enum SearchType
{
    [Description("Low cost search")]
    LOW_COST,

    [Description("Deep for search")]
    DEEP,

    [Description("Breadth for search")]
    BREADTH,
}

public enum CoolingFunction
{
    [Description("Linear cooling")]
    LINEAR,

    [Description("Logarithmic cooling")]
    LOGARITHMIC,

    [Description("Geometric cooling")]
    GEOMETRIC,
}

public enum MutationType
{
    [Description("Inversion mutation")]
    INVERSION,

    [Description("Transposition mutation")]
    TRANSPOSITION,

    [Description("Insertion mutation")]
    INSERTION,
}

public enum CrossoverType
{
    [Description("Order crossover")]
    ORDER,

    [Description("Partially mapped crossover")]
    PMX,
}