﻿/*
 * This file is part of NGrib.
 *
 * Copyright © 2020 Nicolas Mangué
 * 
 * NGrib is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 * 
 * NGrib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with NGrib.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace NGrib.Grib2.Sections.Templates.DataRepresentationTemplates
{
    /// <summary>
    /// Data Representation Template 5.0: Grid point data - simple packing
    /// </summary>
    public class GridPointDataSimplePacking : DataRepresentation
    {
        /// <summary> Reference value (R) (IEEE 32-bit floating-point value).</summary>
        /// <returns> ReferenceValue
        /// </returns>
        public float ReferenceValue { get; }

        /// <summary> Binary scale factor (E).</summary>
        /// <returns> BinaryScaleFactor
        /// </returns>
        public int BinaryScaleFactor { get; }

        /// <summary> Decimal scale factor (D).</summary>
        /// <returns> DecimalScaleFactor
        /// </returns>
        public int DecimalScaleFactor { get; }

        /// <summary> Number of bits used for each packed value..</summary>
        /// <returns> NumberOfBits NB
        /// </returns>
        public int NumberOfBits { get; }

        /// <summary> Type of original field values.</summary>
        /// <returns> OriginalType dataType
        /// </returns>
        public int OriginalType { get; }

        internal GridPointDataSimplePacking(BufferedBinaryReader reader)
        {
            ReferenceValue = reader.ReadSingle();
            BinaryScaleFactor = reader.ReadInt16();
            DecimalScaleFactor = reader.ReadInt16();
            NumberOfBits = reader.ReadUInt8();

            OriginalType = reader.ReadUInt8();
        }

        internal override IEnumerable<float> EnumerateDataValues(BufferedBinaryReader reader, long numberDataPoints)
        {
            var D = DecimalScaleFactor;

            var DD = (float)Math.Pow(10, D);

            var R = ReferenceValue;

            var E = BinaryScaleFactor;

            var EE = (float)Math.Pow(2.0, E);

            //  Y * 10**D = R + (X1 + X2) * 2**E
            //   E = binary scale factor
            //   D = decimal scale factor
            //   R = reference value
            //   X1 = 0
            //   X2 = scaled encoded value 

            for (var i = 0; i < numberDataPoints; i++)
            {
                // (R + ( X1 + X2) * EE)/DD ;
                yield return (R + reader.ReadUIntN(NumberOfBits) * EE) / DD;
            }
        }

				internal override float? MissingValueSubstitute { get; } = null;
    }
}