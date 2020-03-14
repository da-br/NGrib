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

namespace NGrib
{
    public interface IGrib2IdentificationSection
    {
        System.DateTime RefTime { get; }
        int Center_id { get; }
        string Center_idName { get; }
        int Local_table_version { get; }
        int Master_table_version { get; }
        int ProductStatus { get; }
        string ProductStatusName { get; }
        int ProductType { get; }
        string ProductTypeName { get; }
        string ReferenceTime { get; }
        int SignificanceOfRT { get; }
        string SignificanceOfRTName { get; }
        int Subcenter_id { get; }
        int RefTimeT { get; }
    }
}
