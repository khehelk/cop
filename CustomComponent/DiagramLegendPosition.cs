using OxyPlot.Legends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent
{
    public class LegendSettingsAttribute : Attribute
    {
        public LegendPosition Position { get; }
        public LegendPlacement Placement { get; }

        public LegendSettingsAttribute(LegendPosition position, LegendPlacement placement)
        {
            Position = position;
            Placement = placement;
        }
    }

    public enum DiagramLegendPosition
    {
        [LegendSettings(LegendPosition.LeftTop, LegendPlacement.Outside)]
        TopLeftOutside,      // Верхний левый угол
        [LegendSettings(LegendPosition.TopCenter, LegendPlacement.Outside)]
        TopCenterOutside,    // Верхний центр
        [LegendSettings(LegendPosition.RightTop, LegendPlacement.Outside)]
        TopRightOutside,     // Верхний правый угол
        [LegendSettings(LegendPosition.LeftMiddle, LegendPlacement.Outside)]
        MiddleLeftOutside,   // Центр слева        
        [LegendSettings(LegendPosition.RightMiddle, LegendPlacement.Outside)]
        MiddleRightOutside,  // Центр справа
        [LegendSettings(LegendPosition.BottomLeft, LegendPlacement.Outside)]
        BottomLeftOutside,   // Нижний левый угол
        [LegendSettings(LegendPosition.BottomCenter, LegendPlacement.Outside)]
        BottomCenterOutside, // Нижний центр
        [LegendSettings(LegendPosition.BottomRight, LegendPlacement.Outside)]
        BottomRightOutside,   // Нижний правый угол
        [LegendSettings(LegendPosition.LeftTop, LegendPlacement.Inside)]
        TopLeftInside,      // Верхний левый угол
        [LegendSettings(LegendPosition.TopCenter, LegendPlacement.Inside)]
        TopCenterInside,    // Верхний центр
        [LegendSettings(LegendPosition.RightTop, LegendPlacement.Inside)]
        TopRightInside,     // Верхний правый угол
        [LegendSettings(LegendPosition.LeftMiddle, LegendPlacement.Inside)]
        MiddleLeftInside,   // Центр слева
        [LegendSettings(LegendPosition.RightMiddle, LegendPlacement.Inside)]
        MiddleRightInside,  // Центр справа
        [LegendSettings(LegendPosition.BottomLeft, LegendPlacement.Inside)]
        BottomLeftInside,   // Нижний левый угол
        [LegendSettings(LegendPosition.BottomCenter, LegendPlacement.Inside)]
        BottomCenterInside, // Нижний центр
        [LegendSettings(LegendPosition.BottomRight, LegendPlacement.Inside)]
        BottomRightInside,   // Нижний правый угол
    }
}
