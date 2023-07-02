import { useState, useEffect } from "react";
import { HubConnectionBuilder } from "@microsoft/signalr";
import UpdateTable from "../UpdateTable/UpdateTable";
import Station from "../Station/Station";
import StartButton from "../StartButton/StartButton";
import Title from "../Title/Title";
import IFlight from "../../Interfaces/IFlight";
import IStation from "../../Interfaces/IStation";
import "./Airport.css";

const hubUrl = "https://localhost:7263/api/airport/";

const Airport = () => {
  const [routeData, setrouteData] = useState<IStation[] | null>(null);
  const [planeListData, setPlanesDate] = useState<IFlight[] | null>(null);

  const handleClick = () => {
    fetch(hubUrl + "starttimer");
    window.location.reload();
  };

  useEffect(() => {
    const connection = new HubConnectionBuilder().withUrl(hubUrl).build();

    const handlerouteData = async (routeData: IStation[]) => {
      setrouteData(routeData);
      console.log(routeData);
    };

    const getPlanesData = async (planeListData: IFlight[]) => {
      setPlanesDate(planeListData);
      console.log(planeListData);
    };

    connection
      .start()
      .then(() => {
        console.log("Socket connection established.");
        connection.on("GetStations", handlerouteData);
        connection.on("GetFlights", getPlanesData);
      })
      .catch((err) => console.log(err));
  }, []);

  function checkArriving(flight: IFlight) {
    if (flight != null) {
      return flight.isArriving ? (
        <li>{flight.planeNumber + " " + flight.planeName}</li>
      ) : null;
    } else {
      return null;
    }
  }

  function checkDeparting(flight: IFlight) {
    if (flight != null) {
      return !flight.isArriving ? (
        <li>{flight.planeNumber + " " + flight.planeName}</li>
      ) : null;
    } else {
      return null;
    }
  }

  return (
    <>
      <div>
        <div className="main-container">
          <div className="mid-container">
            <Title />
            <div className="stations-container">
              <div className="station-row-1-container">
                <div className="station-4-container">
                  <Station
                    name="Station 9"
                    stations={routeData}
                    stationIndex={9}
                    cssStationClass="station-9 basic-station"
                  />
                </div>
                <div className="station-4-container">
                  <Station
                    name="Station 4"
                    stations={routeData}
                    stationIndex={4}
                    cssStationClass="station-4 basic-station"
                  />
                </div>
                <div className="station-3-2-1-container">
                  <Station
                    name="Station 3"
                    stations={routeData}
                    stationIndex={3}
                    cssStationClass="station-3 basic-station"
                  />
                  <Station
                    name="Station 2"
                    stations={routeData}
                    stationIndex={2}
                    cssStationClass="station-3 basic-station"
                  />
                  <Station
                    name="Station 1"
                    stations={routeData}
                    stationIndex={1}
                    cssStationClass="station-1 basic-station"
                  />
                </div>
              </div>
              <div className="station-row-2-container">
                <div className="station-5-8-container">
                  <Station
                    name="Station 5"
                    stations={routeData}
                    stationIndex={5}
                    cssStationClass="station-5 basic-station"
                  />
                  <Station
                    name="Station 8"
                    stations={routeData}
                    stationIndex={8}
                    cssStationClass="station-8 basic-station"
                  />
                </div>
              </div>
              <div className="station-row-3-container">
                <div className="station-6-7-container">
                  <Station
                    name="Station 6"
                    stations={routeData}
                    stationIndex={6}
                    cssStationClass="station-6 basic-station"
                  />
                  <Station
                    name="Station 7"
                    stations={routeData}
                    stationIndex={7}
                    cssStationClass="station-7 basic-station"
                  />
                </div>
              </div>
            </div>
            <div className="left-table">
              <UpdateTable
                planeListData={planeListData}
                checkFunc={checkArriving}
                tableTitle="Arriving"
              />
            </div>
            <div className="right-table">
              <UpdateTable
                planeListData={planeListData}
                checkFunc={checkDeparting}
                tableTitle="Departing"
              />
            </div>
            <StartButton func={handleClick} />
          </div>
        </div>
      </div>
    </>
  );
};

export default Airport;
