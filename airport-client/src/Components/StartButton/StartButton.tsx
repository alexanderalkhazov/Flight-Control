import './StartButton.css';

interface IStartButtonProps{
   func : any; 
}

const StartButton = ({func} : IStartButtonProps) => {
  return (
    <>
      <div className="btn-container">
        <button onClick={func}>Start</button>
      </div>
    </>
  );
};

export default StartButton;