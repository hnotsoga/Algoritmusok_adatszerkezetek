using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    public static int shop(int n, int k, List<string> centers, List<List<int>> roads)
    {
    
    const int INF = int.MaxValue;

    var fishAtCenter = new int[n];
    for (int i = 0; i < n; i++)
    {
        var data = centers[i].Split(' ').Select(int.Parse).ToArray();
        for (int j = 1; j <= data[0]; j++)
        {
            fishAtCenter[i] |= 1 << (data[j] - 1);
        }
    }

    var graph = new List<(int to, int time)>[n];
    for (int i = 0; i < n; i++)
    {
        graph[i] = new List<(int to, int time)>();
    }
    foreach (var road in roads)
    {
        int u = road[0] - 1, v = road[1] - 1, time = road[2];
        graph[u].Add((v, time));
        graph[v].Add((u, time));
    }
    var dist = new int[n, 1 << k];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < (1 << k); j++)
        {
            dist[i, j] = INF;
        }
    }

    var pq = new SortedSet<(int cost, int node, int mask)>();

    dist[0, fishAtCenter[0]] = 0;
    pq.Add((0, 0, fishAtCenter[0]));

    while (pq.Count > 0)
    {
        var (cost, node, mask) = pq.Min;
        pq.Remove(pq.Min);

        if (cost > dist[node, mask]) continue;

        foreach (var (to, time) in graph[node])
        {
            int newMask = mask | fishAtCenter[to];
            int newCost = cost + time;

            if (newCost < dist[to, newMask])
            {
                dist[to, newMask] = newCost;
                pq.Add((newCost, to, newMask));
            }
        }
    }
    int allFishMask = (1 << k) - 1;
    int result = INF;

    for (int mask1 = 0; mask1 <= allFishMask; mask1++)
    {
        for (int mask2 = 0; mask2 <= allFishMask; mask2++)
        {
            if ((mask1 | mask2) == allFishMask)
            {
                result = Math.Min(result, Math.Max(dist[n - 1, mask1], dist[n - 1, mask2]));
            }
        }
    }

    return result == INF ? -1 : result;
    }
    
}
