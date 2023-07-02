import IStation from "../../Interfaces/IStation";
import FlightIcon from "../FlightIcon/FlightIcon";
import './Station.css';

interface IStationProps {
  stationIndex : number;
  stations : IStation[] | null;
  cssStationClass : string;
  name : string;
}
const Station = ({ stations , stationIndex  , cssStationClass ,name} : IStationProps) => {
  return (
    <>
      <div className={cssStationClass}>
        <h5>{name}</h5>
        <div>
            {stations && stations[stationIndex].currentPlane ? <FlightIcon cssIndex={stationIndex} isArriving={stations[stationIndex].currentPlane.isArriving} /> : null}
            {stations && stations[stationIndex].currentPlane?.planeNumber} <br />
            {stations && stations[stationIndex].currentPlane?.planeName}
        </div>
        
      </div>
    </>
  );
};

export default Station;
