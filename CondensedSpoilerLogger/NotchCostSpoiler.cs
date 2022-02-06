using System;
using System.Text;
using RandomizerMod.Logging;
using Modding;
using UnityEngine;

namespace CondensedSpoilerLogger
{
    public class NotchCostSpoiler : RandoLogger
    {
        public override void Log(LogArguments args)
        {
            if (!args.gs.MiscSettings.RandomizeNotchCosts) return;

            StringBuilder sb = new();

            sb.AppendLine($"Notch costs with 种子: {args.gs.Seed}");
            sb.AppendLine();

            int tot = 0;
            foreach ((string charmName, int charmNum) in CharmIdList.CharmIdMap)
            {
                int cost = args.ctx.notchCosts[charmNum - 1];
                tot += cost;
                sb.AppendLine($"{charmName}: {cost}");
            }

            sb.AppendLine();
            int perc = Mathf.RoundToInt(tot / 90f * 100f);
            sb.AppendLine($"总共: {tot}。 这是原版总和的 {perc}%.");

            LogManager.Write(sb.ToString(), "护符的护符槽费用剧透日志.txt");
        }
    }
}