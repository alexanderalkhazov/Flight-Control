import React from "react";
import IFlight from "../../Interfaces/IFlight";
import './UpdateTable.css';

interface IUpdateTableProps {
  planeListData: IFlight[] | null;
  checkFunc : any;
  tableTitle : string;
}

const UpdateTable = ({ planeListData , checkFunc , tableTitle}: IUpdateTableProps) => {
  return (
    <>
        <div className="tbl">
          <h3>
            <h3>{tableTitle}</h3>
          </h3>
          <div>
            <ol>{planeListData?.map(checkFunc)}</ol>
          </div>
        </div>
    </>
  );
};

export default UpdateTable;
