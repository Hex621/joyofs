﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    interface ITempBoneMaker
    {
        GameObject TempBoneMakerStrategy(List<Component> bones, Component bone);
    }
}
